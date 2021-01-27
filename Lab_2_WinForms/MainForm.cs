using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_WinForms
{
    public partial class MainForm : Form
    {
        private EditInstruments editor;
        private SizeF pictureBoxSizeStart;

        const int startZoom = 10;
        const int startSizeBrush = 4;
        const int startBright = 0;
        const int startContrast = 100;
        const int startRotation = 0;

        public MainForm()
        {
            InitializeComponent();
            SetStartValues();
        }

        private void SetStartValues()
        {
            trckbrBrushSize.Value = startSizeBrush;
            trckbrZoom.Value = startZoom;
            trckbarContrast.Value = startContrast;
            trckbarBright.Value = startBright;
            trckbrRotation.Value = startRotation;
            pnlDrawing.Visible = false;
            pnlZoom.Visible = false;
            pnlRotation.Visible = false;
            pnlColours.Visible = false;
            ratio = 1;
            wasRotated = false;
        }

        bool firstSave = true;
        string savePath;

        private void SaveNewDialog()
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Image Files(*.bmp)|*.bmp|Image Files(*.jpg)|*.jpg|Image Files(*.png)|*.png|All files (*.*)|*.*";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picbxField.Image.Save(savedialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            savePath = savedialog.FileName;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (picbxField.Image != null)
            {
                if (firstSave == false)
                    picbxField.Image.Save(savePath);
                else
                {
                    SaveNewDialog();
                    firstSave = false;
                }
            }
        }

        private void toolSaveAs_Click(object sender, EventArgs e)
        {
            if (picbxField.Image != null)
                SaveNewDialog();
        }

        Bitmap bitmap1; 
        private void toolLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*string picName = openFileDialog1.FileName.Replace(@"\", @"\\");
                Image image = Image.FromFile(picName);
                editor = new EditInstruments(image, picName);
                picbxField.Size = image.Size;
                picbxField.Image = editor.AdjustedImage;
                pictureBoxSizeStart = picbxField.Size;*/
                string picName = openFileDialog1.FileName.Replace(@"\", @"\\");
                bitmap1 = (Bitmap)Bitmap.FromFile(picName);
                picbxField.Size = bitmap1.Size;
                editor = new EditInstruments(bitmap1, picName);
                picbxField.Image = editor.AdjustedImage;
                pictureBoxSizeStart = picbxField.Size;

            }
        }

        private Color brushColor = Color.Black;
        bool checkDrawing = false;
        bool availDrawing = false;

        private void toolDrawing_Click(object sender, EventArgs e)
        {
            pnlDrawing.Visible = true;
            availDrawing = true;
            pnlZoom.Visible = false;
            pnlColours.Visible = false;
            pnlRotation.Visible = false;
          //  wasRotated = false;
        }

        private void toolZoom_Click(object sender, EventArgs e)
        {
            pnlZoom.Visible = true;
            pnlDrawing.Visible = false;
            pnlColours.Visible = false;
            pnlRotation.Visible = false;
        }

        private void toolRotation_Click(object sender, EventArgs e)
        {
            pnlDrawing.Visible = false;
            pnlZoom.Visible = false;
            pnlRotation.Visible = true;
            pnlColours.Visible = false;
        }

        Bitmap nonRotatedImage = null;
        bool wasRotated;


        private void trckbrRotation_Scroll(object sender, EventArgs e)
        {
            if (editor != null)
            {
                if (!wasRotated) {
                    nonRotatedImage = editor.AdjustedImage;
                    picbxField.Image = editor.RotateImage(trckbrRotation.Value, editor.AdjustedImage);
                    wasRotated = true;
                } else
                {
                    editor.AdjustedImage = nonRotatedImage;
                    picbxField.Image = editor.RotateImage(trckbrRotation.Value, editor.AdjustedImage);
                }
                if (trckbrRotation.Value == 0)
                {
                    wasRotated = false;
                }
                
            }
        } 

        private void toolFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (editor != null)
            {
                editor.AdjustedImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                picbxField.Image = editor.AdjustedImage;
            }
        }

        private void toolFlipVertical_Click(object sender, EventArgs e)
        {
            if (editor != null)
            {
                editor.AdjustedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                picbxField.Image = editor.AdjustedImage;
            }
        }

        private void pnlBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pnlBrushColor.BackColor = brushColor = colorDialog1.Color;
            return;    
        }

        private void picbxField_MouseDown(object sender, MouseEventArgs e)
        {
            checkDrawing = true;      
        }

        private void picbxField_MouseUp(object sender, MouseEventArgs e)
        {
            checkDrawing = false;
        }

        private Point ScalePoint(Point point)
        {
            return new Point((int)(point.X / ratio), (int)(point.Y / ratio));
        }

        private void picbxField_MouseMove(object sender, MouseEventArgs e)
        {
            if ((checkDrawing) && (availDrawing) && (picbxField.Image != null))
            {
                int Size = trckbrBrushSize.Value*2;
                SolidBrush brush = new SolidBrush(brushColor);
                try { 
                    using (Graphics graphics = Graphics.FromImage(editor.AdjustedImage))
                    {
                        //Point currentPoint = e.Location;
                        Point currentPoint = ScalePoint(e.Location);
                        graphics.DrawEllipse(new Pen(brushColor, 1), currentPoint.X - (Size / 2), currentPoint.Y - (Size / 2), Size, Size);
                        graphics.FillEllipse(brush, currentPoint.X - (Size / 2), currentPoint.Y - (Size / 2), Size, Size);

                       // finPoint = currentPoint;
                    }
                }
                catch
                {                  
                    return;
                }
                picbxField.Invalidate();
            }
        }

        private void toolReset_Click(object sender, EventArgs e)
        {
            if (editor != null)
            {
                editor.AdjustedImage = editor.OriginalImage;
                picbxField.Image = editor.AdjustedImage;
                picbxField.Invalidate();
                SetStartValues();
                trckbrZoom_Scroll_1(sender, e);
            }
        }

        float ratio = 1;
        private void trckbrZoom_Scroll_1(object sender, EventArgs e)
        {
            int zoom = trckbrZoom.Value;
            if (zoom != 0)
            {
                ratio = (float)zoom / (float)startZoom;
                picbxField.Width = (int)(pictureBoxSizeStart.Width * ratio);
                picbxField.Height = (int)(pictureBoxSizeStart.Height * ratio);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (editor!=null) { 
                picbxField.Size = editor.AdjustedImage.Size;
                trckbrZoom_Scroll_1(sender, e);
            }
        }

        private void toolRegulations_Click(object sender, EventArgs e)
        {
            pnlColours.Visible = true;
            pnlDrawing.Visible = false;
            pnlZoom.Visible = false;
            pnlRotation.Visible = false;
        }

        private void trckbarBright_Scroll(object sender, EventArgs e)
        {
            if (editor != null)
            {
                picbxField.Image = editor.AdjustBrightnessContrast(
                    trckbarBright.Value, trckbarContrast.Value);
            }
        }

        private void trckbarContrast_Scroll(object sender, EventArgs e)
        {
            if (editor != null)
            {
                picbxField.Image = editor.AdjustBrightnessContrast(
                    trckbarBright.Value, trckbarContrast.Value);
            }
        }


    }
}
