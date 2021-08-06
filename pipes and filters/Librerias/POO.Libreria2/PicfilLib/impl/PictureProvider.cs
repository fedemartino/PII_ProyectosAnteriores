using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PicfilLib
{
    /// <summary>
    /// Un proveedor de imagenes que lee imagenes del disco.
    /// </summary>
    /// <remarks>
    /// La imagen se busca relativa al lugar donde se ejecuta el proyecto.
    /// </remarks>
    public class PictureProvider : IPictureProvider
    {
        /// <summary>
        /// Carga la imagen con el nombre de archivo pasado por parametro en la imagen pasada por parametro.
        /// </summary>
        /// <remarks>
        /// Si el tamanio de la imagen leida no coincide con la pasada por parametro, se cambia el tamanio 
        /// de la imagen pasada por parametro mediante la operacion <code>IPicture.Resize</code>.
        /// </remarks>
        /// <param name="name"></param>
        /// <param name="picture"></param>
        public void ReadIntoImage(String name, IPicture picture)
        {
            Bitmap bitmap = new Bitmap(name);
            picture.Resize(bitmap.Width, bitmap.Height);

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0,
                        bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadOnly,
                        PixelFormat.Format32bppArgb);            
            ReadIntoImage(bitmapData, picture);
            bitmap.UnlockBits(bitmapData);
        }

        private void ReadIntoImage(BitmapData bitmapData, IPicture picture)
        {
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData.Scan0;
                for (int x = 0; x < Math.Min(bitmapData.Width, picture.Width); x++)
                {
                    for (int y = 0; y < Math.Min(bitmapData.Height, picture.Height); y++)
                    {
                        picture.SetColor(x, y, Color.FromArgb(                            
                            imagePointer1[3],
                            imagePointer1[0],
                            imagePointer1[1],
                            imagePointer1[2]
                            ));
                        imagePointer1 += 4;
                    }
                    imagePointer1 += bitmapData.Stride -
                               (bitmapData.Width * 4);
                }
            }
            
        }                
    }
}
