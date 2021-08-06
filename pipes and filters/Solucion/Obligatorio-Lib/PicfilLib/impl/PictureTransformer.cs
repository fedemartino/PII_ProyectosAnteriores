using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace PicfilLib
{
    /// <summary>
    /// Clase interna para transformar una IPicture a un Bitmap .NET.
    /// </summary>
    class PictureTransformer
    {
        /// <summary>
        /// Transforma una IPicture en un Bitmap .NET.
        /// </summary>
        /// <param name="picture">la IPicture</param>
        /// <returns>el Bitmap</returns>
        public Bitmap GetBitmap(IPicture picture)
        {
            Debug.Assert(picture != null);

            Bitmap bitmap = new Bitmap(picture.Width - 10, picture.Height - 10);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0,
                    bitmap.Width, bitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);

            Int32 bitsPerPixel = 4;
            Int32 offset = bitmapData.Stride - (bitmapData.Width * bitsPerPixel);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData.Scan0;
                for (int y = 0; y < bitmapData.Height; y++)
                {
                    for (int x = 0; x < bitmapData.Width; x++)
                    {
                        Int32 color = picture.GetColor(x, y).ToArgb();
                        imagePointer1[0] = (byte)((color & 0xFF0000) >> 16);
                        imagePointer1[1] = (byte)((color & 0xFF00) >> 8);
                        imagePointer1[2] = (byte)((color & 0xFF));
                        imagePointer1[3] = (byte)((color & 0xFF000000) >> 24); ;
                        imagePointer1 += bitsPerPixel;
                    }
                    imagePointer1 += offset;
                }
            }
            bitmap.UnlockBits(bitmapData);

            Debug.Assert(bitmap != null);

            return bitmap;
        }
    }
}
