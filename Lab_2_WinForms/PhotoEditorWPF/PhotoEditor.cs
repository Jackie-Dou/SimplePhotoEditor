using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Point = System.Drawing.Point;

namespace Lab_2_WPF
{
    class PhotoEditor
    {
        private const double DegToRad = 0.017453292519943295;

        private Image OriginalImage { get; set; }
        public Image AdjustedImage { get; private set; }
        private string OriginalImagePath { get; }
        public string ImagePath { get; private set; }

        public PhotoEditor(Image image, string imagePath)
        {
            OriginalImage = image;
            AdjustedImage = (Image)image.Clone();
            OriginalImagePath = imagePath;
        }

        public PhotoEditor(BitmapImage bitmapImage, string imagePath)
        {
            var bitmap = BitmapImage2Bitmap(bitmapImage);
            OriginalImage = bitmap;
            AdjustedImage = (Image) bitmap.Clone();
            OriginalImagePath = imagePath;
        }

        public Image AdjustImage(int brightnessValue, int contrastValue, int rotationAngle)
        {
            if (OriginalImage == null)
                return null;
            AdjustBrightnessContrast(brightnessValue, contrastValue);
            RotateImage(rotationAngle);
            return AdjustedImage;
        }

        private void AdjustBrightnessContrast(int brightnessValue, int contrastValue)
        {
            var brightness = brightnessValue / 100.0F;
            var contrast = contrastValue / 100.0F;
            using (var bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height, PixelFormat.Format32bppArgb))
            using (var g = Graphics.FromImage(bitmap))
            using (var imageAttributes = new ImageAttributes())
            {
                float[][] matrix =
                {
                    new[] {contrast, 0, 0, 0, 0 },
                    new[] {0, contrast, 0, 0, 0 },
                    new[] {0, 0, contrast, 0, 0 },
                    new float[] {0, 0, 0, 1, 0 },
                    new[] {brightness, brightness, brightness, 1, 1 }
                };
                var colorMatrix = new ColorMatrix(matrix);
                imageAttributes.SetColorMatrix(colorMatrix);
                g.DrawImage(OriginalImage,
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    0, 0, bitmap.Width, bitmap.Height,
                    GraphicsUnit.Pixel, imageAttributes
                    );
                AdjustedImage = (Bitmap)bitmap.Clone();
            }
        }

        internal Image Reset()
        {
            AdjustedImage = OriginalImage;
            return AdjustedImage;
        }


        private Image RotateImage(int rotationAngle)
        {
            rotationAngle = NormalizeAngle(rotationAngle);
            if (rotationAngle == 0)
                return AdjustedImage;
            var sin = (float)Math.Sin(rotationAngle % 90 * DegToRad);
            var cos = (float)Math.Cos(rotationAngle % 90 * DegToRad);
            float oldWidth = AdjustedImage.Width;
            float oldHeight = AdjustedImage.Height;
            var newWidth = 0f;
            var newHeight = 0f;
            var originX = 0f;
            var originY = 0f;
            if (rotationAngle < 90)
            {
                newWidth = sin * oldHeight + cos * oldWidth;
                newHeight = sin * oldWidth + cos * oldHeight;

                originX = sin * oldHeight;
                originY = 0f;
            }
            else if (rotationAngle > 270)
            {
                newHeight = sin * oldHeight + cos * oldWidth;
                newWidth = sin * oldWidth + cos * oldHeight;

                originX = 0f;
                originY = cos * oldWidth;
            }
            var bmp = new Bitmap((int)newWidth, (int)newHeight);
            bmp.SetResolution(AdjustedImage.HorizontalResolution, AdjustedImage.VerticalResolution);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.TranslateTransform(originX, originY);
                gr.RotateTransform(rotationAngle);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(AdjustedImage, new Point(0, 0));
            }
            AdjustedImage = bmp;
            return AdjustedImage;
        }

        private static int NormalizeAngle(int angle)
        {
            angle %= 360;
            if (angle < 0)
                angle += 360;
            return angle;
        }

        public void SaveImage(string path)
        {
            if ((AdjustedImage == null) || (OriginalImage == null))
                return;
            if (String.IsNullOrEmpty(path))
                return;
            if (path.Equals(OriginalImagePath))
            {
                OriginalImage.Dispose();
                OriginalImage = AdjustedImage;
            }
            if (File.Exists(path))
                File.Delete(path);
            AdjustedImage.Save(path);
            ImagePath = path;
        }

        public void SaveImage()
        {
            SaveImage(ImagePath);
        }
        
        private static Bitmap BitmapImage2Bitmap(BitmapSource bitmapImage)
        {
            using(var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                var bitmap = new Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }

        public Image DrawOnImage(double x, double y, Color brushColor, int brushSize)
        {
            using (var graphics = Graphics.FromImage(AdjustedImage))
            {
                var currentPoint = new Point((int) x, (int) y);
                var size = brushSize;
                var brush = new SolidBrush(brushColor);
                graphics.DrawEllipse(new Pen(brushColor, 1), currentPoint.X - (size / 2),
                    currentPoint.Y - (size / 2), size, size);
                graphics.FillEllipse(brush, currentPoint.X - (size / 2), 
                    currentPoint.Y - (size / 2), size, size);
            }
            return AdjustedImage;
        }
    }
}
