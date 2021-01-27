using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace Lab_2_WinForms
{
    class EditInstruments
    {
        const double DEG_TO_RAD = 0.017453292519943295;

        /*  public Image OriginalImage { get; set; }
          public Image AdjustedImage { get; set; } */

        public Bitmap OriginalImage { get; set; }
        public Bitmap AdjustedImage { get; set; }
        public string OriginalImagePath { get; set; }

        public EditInstruments(Bitmap image, string imagePath)
        {
            this.OriginalImage = image;
            this.AdjustedImage = (Bitmap)image.Clone();
            this.OriginalImagePath = imagePath;
        }

        public Image AdjustBrightnessContrast(int brightnessValue, int contrastValue)
         {
             float brightness = brightnessValue / 100.0F;
             float contrast = contrastValue / 100.0F;

             using (Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height, PixelFormat.Format32bppArgb))
             using (Graphics g = Graphics.FromImage(bitmap))
             using (ImageAttributes imageAttributes = new ImageAttributes())
             {
                 float[][] matrix =
                 {
                     new float[] {contrast, 0, 0, 0, 0 },
                     new float[] {0, contrast, 0, 0, 0 },
                     new float[] {0, 0, contrast, 0, 0 },
                     new float[] {0, 0, 0, 1, 0 },
                     new float[] {brightness, brightness, brightness, 1, 1 }
                 };

                 ColorMatrix colorMatrix = new ColorMatrix(matrix);
                 imageAttributes.SetColorMatrix(colorMatrix);
                 g.DrawImage(OriginalImage,
                     new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                     0, 0, bitmap.Width, bitmap.Height,
                     GraphicsUnit.Pixel, imageAttributes
                     );

                 AdjustedImage = (Bitmap)bitmap.Clone();
                 return AdjustedImage;
             }
        }

        public float newWidth = 0f;
        public float newHeight = 0f;

       // float oldWidth = 400;
       // float oldHeight = 400;

       // private int prevAngle;

        public Bitmap RotateImage(int rotationAngle, Bitmap workImage)
        {
            rotationAngle = NormalizeAngle(rotationAngle);
            if (rotationAngle == 0)
            {
                this.AdjustedImage = workImage;
                return this.AdjustedImage;
            }
            this.AdjustedImage = workImage;
            //AdjustedImage = OriginalImage;
            float sin = (float)Math.Sin(rotationAngle % 90 * DEG_TO_RAD);
            float cos = (float)Math.Cos(rotationAngle % 90 * DEG_TO_RAD);
            float oldWidth = AdjustedImage.Width;
            float oldHeight = AdjustedImage.Height;
            float originX = 0f;
            float originY = 0f;
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
            Bitmap bmp = new Bitmap((int)newWidth, (int)newHeight);
            bmp.SetResolution(AdjustedImage.HorizontalResolution, AdjustedImage.VerticalResolution);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.TranslateTransform(originX, originY);
                gr.RotateTransform(rotationAngle);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(AdjustedImage, new Point(0, 0));
            }
            this.AdjustedImage = bmp;
            return this.AdjustedImage;
        }

        private static int NormalizeAngle(int angle)
        {
            angle %= 360;
            if (angle < 0)
                angle += 360;
            return angle;
        }

    }
}

