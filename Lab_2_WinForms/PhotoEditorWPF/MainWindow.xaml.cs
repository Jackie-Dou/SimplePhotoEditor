using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Button = System.Windows.Controls.Button;
using Color = System.Drawing.Color;
using MessageBox = System.Windows.Forms.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;

namespace Lab_2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private PhotoEditor _photoEditor;

        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog
        {
            Filter = @"Файлы изображений|*.bmp;*.png;*.jpg"
        };

        private readonly SaveFileDialog _saveFileDialog = new SaveFileDialog
        {
            Filter = @"Jpg файл|*.jpg|Bmp файл|*.bmp|Png файл|*.png|Все файлы|*.*"
        };

        private readonly ColorDialog _colorDialog = new ColorDialog();
        private Color _brushColor = Color.Black;
        private bool _isDrawing;
        private int _brushSize = 20;

        private float _zoom;
        private RectangleF _imageArea;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenImage(object sender, ExecutedRoutedEventArgs e)
        {
            if (_openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            try
            {
                var bitmapImage = new BitmapImage(new Uri("file://" + _openFileDialog.FileName));
                _photoEditor = new PhotoEditor(bitmapImage, _openFileDialog.FileName);
                PictureBox.Source = bitmapImage;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(@"Ошибка чтения картинки!");
                return;
            }
            SetImageScale();
            SetDefaultValues();
            SaveMenuItem.IsEnabled = true;
            SaveAsMenuItem.IsEnabled = true;
        }

        private void SaveImage(object sender, ExecutedRoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
            if (string.IsNullOrEmpty(_photoEditor.ImagePath))
            {
                SaveImageAs(sender, e);
                return;
            }
            _photoEditor.SaveImage();
        }

        private void SaveImageAs(object sender, ExecutedRoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
            if (_saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            _photoEditor.SaveImage(_saveFileDialog.FileName);
        }

        private void RefreshImage(object sender, ExecutedRoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
            var image = _photoEditor.Reset();
            PictureBox.Source = Drawing2BmpImgBitmapImage(image);
            SetDefaultValues();
        }

        private void SlidersChanged(object sender, DragCompletedEventArgs dragCompletedEventArgs)
        {
            if (_photoEditor == null)
                return;
            var image = _photoEditor.AdjustImage(
                (int)BrightnessSlider.Value,
                (int)ContrastSlider.Value,
                (int)RotationSlider.Value);
            PictureBox.Source = Drawing2BmpImgBitmapImage(image);
        }

        private void RotateFlipImage(object sender, RoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
            var image = _photoEditor.AdjustImage(
                (int)BrightnessSlider.Value,
                (int)ContrastSlider.Value,
                (int)RotationSlider.Value);
            PictureBox.Source = Drawing2BmpImgBitmapImage(image);
        }

        private void FlipHorizontalImage(object sender, RoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
             _photoEditor.AdjustedImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            PictureBox.Source = Drawing2BmpImgBitmapImage(_photoEditor.AdjustedImage);
        }

        private void FlipVerticalImage(object sender, RoutedEventArgs e)
        {
            if (_photoEditor == null)
                return;
            _photoEditor.AdjustedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            PictureBox.Source = Drawing2BmpImgBitmapImage(_photoEditor.AdjustedImage);
        }

        private void ShowCorrectionControls(object sender, RoutedEventArgs e)
        {
            DrawPanel.Visibility = Visibility.Collapsed;
            RotationPanel.Visibility = Visibility.Collapsed;
            CorrectionPanel.Visibility = Visibility.Visible;
        }

        private void ShowRotationControls(object sender, RoutedEventArgs e)
        {
            DrawPanel.Visibility = Visibility.Collapsed;
            CorrectionPanel.Visibility = Visibility.Collapsed;
            RotationPanel.Visibility = Visibility.Visible;
        }

        private void ShowDrawControls(object sender, RoutedEventArgs e)
        {
            RotationPanel.Visibility = Visibility.Collapsed;
            CorrectionPanel.Visibility = Visibility.Collapsed;
            DrawPanel.Visibility = Visibility.Visible;
        }

        private void PictureBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = true;
        }

        private void PictureBox_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (PictureBox.Source == null || _isDrawing == false)
                return;
            var point = ScalePoint(e.GetPosition(PictureBox));
            var image = _photoEditor.DrawOnImage(point.X, point.Y, _brushColor, _brushSize);
            PictureBox.Source = Drawing2BmpImgBitmapImage(image);
        }

        private void PictureBox_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = false;
        }

        private void ChangeBrushColor(object sender, RoutedEventArgs e)
        {
            if (_colorDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            var color = System.Windows.Media.Color.FromArgb(_colorDialog.Color.A,
                _colorDialog.Color.R, _colorDialog.Color.G, _colorDialog.Color.B);
            BrushPanel.Background = new SolidColorBrush(color);
            _brushColor = _colorDialog.Color;
        }

        private void ChangeBrushSize(object sender, DragCompletedEventArgs e)
        {
            _brushSize = (int) BrushSizeSlider.Value;
        }

        private void SetDefaultValues()
        {
            BrightnessSlider.Value = 0;
            ContrastSlider.Value = 100;
            RotationSlider.Value = 0;
        }

        private Point ScalePoint(Point point)
        {
            return new Point(
                (int) ((point.X - _imageArea.X) / _zoom),
                (int) ((point.Y - _imageArea.Y) / _zoom)
            );
        }

        private void SetImageScale()
        {
            if (_photoEditor == null)
                return;
            var pictureBoxSize = new SizeF((float) Grid.ActualWidth, (float) Grid.ActualHeight);
            SizeF imageSize = _photoEditor.AdjustedImage.Size;
            var pictureBoxRatios = 1f * pictureBoxSize.Width / pictureBoxSize.Height;
            var imageRatios = 1f * imageSize.Width / imageSize.Height;
            if (pictureBoxRatios > imageRatios)
            {
                _zoom = pictureBoxSize.Height / imageSize.Height;
                var width = imageSize.Width * _zoom;
                var left = (pictureBoxSize.Width / (pictureBoxRatios / imageRatios) - width) / 2;
                _imageArea = new RectangleF(left, 0, width, pictureBoxSize.Height);
            }
            else
            {
                _zoom = pictureBoxSize.Width / imageSize.Width;
                var height = imageSize.Height * _zoom;
                var top = (pictureBoxSize.Height / (imageRatios / pictureBoxRatios) - height) / 2f;
                _imageArea = new RectangleF(0, top, pictureBoxSize.Width, height);
            }
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Byte[]")]
        [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH",
            MessageId = "type: System.Byte[]")]
        private static BitmapImage Drawing2BmpImgBitmapImage(Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Bmp);
                stream.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetImageScale();
        }
    }
}