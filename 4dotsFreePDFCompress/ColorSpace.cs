using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace _4dotsFreePDFCompress
{
    public class YUV
    {
        public byte Y;
        public byte U;
        public byte V;

        public YUV(byte Y, byte U, byte V)
        {
            this.Y = Y;
            this.U = U;
            this.V = V;
        }

        public static YUV FromRGB(Color c)
        {
            byte Y, U, V;

            Y = (byte)(((66 * c.R + 129 * c.G + 25 * c.B + 128) >> 8) + 16);
            U = (byte)(((-38 * c.R - 74 * c.G + 112 * c.B + 128) >> 8) + 128);
            V = (byte)(((112 * c.R - 94 * c.G - 18 * c.B + 128) >> 8) + 128);

            return new YUV(Y, U, V);
        }

        public Color RGB
        {
            get
            {
                int C = Y - 16;
                int D = U - 128;
                int E = V - 128;

                byte R, G, B;

                R = (byte)Math.Max(Math.Min(((298 * C + 409 * E + 128) >> 8), 255), 0);
                G = (byte)Math.Max(Math.Min(((298 * C - 100 * D - 208 * E + 128) >> 8), 255), 0);
                B = (byte)Math.Max(Math.Min(((298 * C + 516 * D + 128) >> 8), 255), 0);

                return Color.FromArgb(R, G, B);
            }
        }
    }

    public class HSL
    {
        private float h;
        private float s;
        private float l;

        public float Hue
        {
            get
            {
                return h;
            }
            set
            {
                h = (float)(Math.Abs(value) % 360);
            }
        }

        public float Saturation
        {
            get
            {
                return s;
            }
            set
            {
                s = (float)Math.Max(Math.Min(1.0, value), 0.0);
            }
        }

        public float Luminance
        {
            get
            {
                return l;
            }
            set
            {
                l = (float)Math.Max(Math.Min(1.0, value), 0.0);
            }
        }

        private HSL()
        {
        }
        public HSL(float hue, float saturation, float luminance)
        {
            Hue = hue;
            Saturation = saturation;
            Luminance = luminance;
        }


        public Color RGB
        {
            get
            {
                double r = 0, g = 0, b = 0;

                double temp1, temp2;

                double normalisedH = h / 360.0;

                if (l == 0)
                {
                    r = g = b = 0;
                }
                else
                {
                    if (s == 0)
                    {
                        r = g = b = l;
                    }
                    else
                    {
                        temp2 = ((l <= 0.5) ? l * (1.0 + s) : l + s - (l * s));

                        temp1 = 2.0 * l - temp2;

                        double[] t3 = new double[] { normalisedH + 1.0 / 3.0, normalisedH, normalisedH - 1.0 / 3.0 };

                        double[] clr = new double[] { 0, 0, 0 };

                        for (int i = 0; i < 3; ++i)
                        {
                            if (t3[i] < 0)
                                t3[i] += 1.0;

                            if (t3[i] > 1)
                                t3[i] -= 1.0;

                            if (6.0 * t3[i] < 1.0)
                                clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
                            else if (2.0 * t3[i] < 1.0)
                                clr[i] = temp2;
                            else if (3.0 * t3[i] < 2.0)
                                clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                            else
                                clr[i] = temp1;

                        }

                        r = clr[0];
                        g = clr[1];
                        b = clr[2];
                    }

                }
                return Color.FromArgb(Convert.ToInt32(255 * r), Convert.ToInt32(255 * g), Convert.ToInt32(255 * b));
            }
        }

        private static byte toRGB(float rm1, float rm2, float rh)
        {
            if (rh > 360) rh -= 360;
            else if (rh < 0) rh += 360;

            if (rh < 60) rm1 = rm1 + (rm2 - rm1) * rh / 60;
            else if (rh < 180) rm1 = rm2;
            else if (rh < 240) rm1 = rm1 + (rm2 - rm1) * (240 - rh) / 60;

            return (byte)(rm1 * 255);
        }


        public static HSL FromRGB(byte red, byte green, byte blue)
        {
            return FromRGB(Color.FromArgb(red, green, blue));
        }

        public static HSL FromRGB(Color c)
        {
            return new HSL(c.GetHue(), c.GetSaturation(), c.GetBrightness());
        }
    }

    /// <summary>
    /// Summary description for ColorSpace.
    /// </summary>
    public class ColorSpace
    {
        public ColorSpace()
        {
        }

        public static Bitmap Luminance(Bitmap source, float factor)
        {
            int width = source.Width;
            int height = source.Height;

            Rectangle rc = new Rectangle(0, 0, width, height);

            if (source.PixelFormat != PixelFormat.Format24bppRgb) source = source.Clone(rc, PixelFormat.Format24bppRgb);

            Bitmap dest = new Bitmap(width, height, source.PixelFormat);

            BitmapData dataSrc = source.LockBits(rc, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dataDest = dest.LockBits(rc, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int offset = dataSrc.Stride - (width * 3);

            unsafe
            {
                byte* bytesSrc = (byte*)(void*)dataSrc.Scan0;
                byte* bytesDest = (byte*)(void*)dataDest.Scan0;

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        HSL hsl = HSL.FromRGB(bytesSrc[2], bytesSrc[1], bytesSrc[0]); // Still BGR
                        hsl.Luminance *= factor;

                        Color c = hsl.RGB;

                        bytesDest[0] = c.B;
                        bytesDest[1] = c.G;
                        bytesDest[2] = c.R;

                        bytesSrc += 3;
                        bytesDest += 3;
                    }

                    bytesDest += offset;
                    bytesSrc += offset;
                }

                source.UnlockBits(dataSrc);
                dest.UnlockBits(dataDest);
            }

            return dest;
        }

        public static Bitmap Hue(Bitmap source, float factor)
        {
            int width = source.Width;
            int height = source.Height;

            Rectangle rc = new Rectangle(0, 0, width, height);

            if (source.PixelFormat != PixelFormat.Format24bppRgb) source = source.Clone(rc, PixelFormat.Format24bppRgb);

            Bitmap dest = new Bitmap(width, height, source.PixelFormat);

            BitmapData dataSrc = source.LockBits(rc, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dataDest = dest.LockBits(rc, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int offset = dataSrc.Stride - (width * 3);

            unsafe
            {
                byte* bytesSrc = (byte*)(void*)dataSrc.Scan0;
                byte* bytesDest = (byte*)(void*)dataDest.Scan0;

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        HSL hsl = HSL.FromRGB(bytesSrc[2], bytesSrc[1], bytesSrc[0]); // Still BGR
                        hsl.Hue *= factor;

                        Color c = hsl.RGB;

                        bytesDest[0] = c.B;
                        bytesDest[1] = c.G;
                        bytesDest[2] = c.R;

                        bytesSrc += 3;
                        bytesDest += 3;
                    }

                    bytesDest += offset;
                    bytesSrc += offset;
                }

                source.UnlockBits(dataSrc);
                dest.UnlockBits(dataDest);
            }

            return dest;
        }

        public static Bitmap Saturation(Bitmap source, float factor)
        {
            int width = source.Width;
            int height = source.Height;

            Rectangle rc = new Rectangle(0, 0, width, height);

            if (source.PixelFormat != PixelFormat.Format24bppRgb) source = source.Clone(rc, PixelFormat.Format24bppRgb);

            Bitmap dest = new Bitmap(width, height, source.PixelFormat);

            BitmapData dataSrc = source.LockBits(rc, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dataDest = dest.LockBits(rc, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int offset = dataSrc.Stride - (width * 3);

            unsafe
            {
                byte* bytesSrc = (byte*)(void*)dataSrc.Scan0;
                byte* bytesDest = (byte*)(void*)dataDest.Scan0;

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        HSL hsl = HSL.FromRGB(bytesSrc[2], bytesSrc[1], bytesSrc[0]); // Still BGR
                        hsl.Saturation *= factor;

                        Color c = hsl.RGB;

                        bytesDest[0] = c.B;
                        bytesDest[1] = c.G;
                        bytesDest[2] = c.R;

                        bytesSrc += 3;
                        bytesDest += 3;
                    }

                    bytesDest += offset;
                    bytesSrc += offset;
                }

                source.UnlockBits(dataSrc);
                dest.UnlockBits(dataDest);
            }

            return dest;
        }

        public static Bitmap Grayscale(Bitmap source)
        {
            Bitmap adjustedImage = (Bitmap)source.Clone();

            // create matrix that will brighten and contrast the image
            ColorMatrix cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
            new float[] {0.30f, 0.30f, 0.30f, 0, 0},
            new float[] {0.59f, 0.59f, 0.59f, 0, 0},
            new float[] {0.11f, 0.11f, 0.11f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
            });

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(cmPicture, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                g.DrawImage(source, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, source.Width, source.Height,
                GraphicsUnit.Pixel, imageAttributes);
            }

            return adjustedImage;
        }

        public static Bitmap Negative(Bitmap source)
        {
            Bitmap adjustedImage = (Bitmap)source.Clone();

            // create matrix that will brighten and contrast the image
            ColorMatrix cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
            new float[] {-1, 0, 0, 0, 0},
            new float[] {0, -1, 0, 0, 0},
            new float[] {0, 0, -1, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {1, 1, 1, 0, 1}
            });

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(cmPicture, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                g.DrawImage(source, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                    , 0, 0, source.Width, source.Height,
                    GraphicsUnit.Pixel, imageAttributes);
            }

            return adjustedImage;
        }

        public static Bitmap Sepia(Bitmap source)
        {
            Bitmap adjustedImage = (Bitmap)source.Clone();

            float[][] ptsArray = null;

            ptsArray = new float[][]{
                       new float[] {.393f, .349f, .272f, 0, 0},
                       new float[] {.769f, .686f, .534f, 0, 0},
                       new float[] {.189f, .168f, .131f, 0, 0},
                       new float[] {0, 0, 0, 1, 0},
                       new float[] {0, 0, 0, 0, 1}
                   };

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height)
                    , 0, 0, source.Width, source.Height,
                    GraphicsUnit.Pixel, imageAttributes);
            }

            return adjustedImage;
        }

        /// <summary>
        /// Transforms an image to black and white.
        /// </summary>
        /// <param name="img">The image.</param>
        /// <returns>The black and white image.</returns>
        public static Bitmap GetBlackAndWhiteImage(Bitmap bmp)
        {
            System.Drawing.Imaging.ColorMatrix grayMatrix = new ColorMatrix(
                    new float[][] {
            new float[] { 0.299f, 0.299f, 0.299f, 0, 0  },
            new float[] { 0.587f, 0.587f, 0.587f, 0, 0  },
            new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
            new float[] { 0, 0, 0, 1, 0 },
            new float[] { 0, 0, 0, 0, 1}
        });

            using (Graphics g = Graphics.FromImage(bmp))
            {

                using (System.Drawing.Imaging.ImageAttributes ia = new System.Drawing.Imaging.ImageAttributes())
                {                    
                    ia.SetColorMatrix(grayMatrix);
                    ia.SetThreshold((float)0.5);

                    g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia);

                }

            }
            return bmp;
        }
    }

}



