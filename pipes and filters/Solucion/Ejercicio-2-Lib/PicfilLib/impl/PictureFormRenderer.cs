using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace PicfilLib
{
    /// <summary>
    /// Un desplegador de imagenes que utiliza una ventana para mostrar la imagen.
    /// </summary>
    public class PictureFormRenderer : IPictureRenderer
    {
        private readonly Form main;

        /// <summary>
        /// Inicializa un nuevo desplegador.
        /// </summary>
        public PictureFormRenderer()
        {
            this.main = null;
        }

        /// <summary>
        /// Inicializa un nuevo desplegador que despliega en la ventana indicada.
        /// </summary>
        /// <param name="main">la ventana donde desplegar la imagen</param>
        public PictureFormRenderer(Form main)
        {
            this.main = main;
        }

        /// <summary>
        /// Despliega la imagen en una ventana.
        /// </summary>
        /// <remarks>
        /// Si no se definio la ventana al constuir el desplegador, se crea una nueva 
        /// ventana para desplegar la imagen.
        /// </remarks>
        /// <param name="picture">la imagen</param>
        public void Render(IPicture picture)
        {
            if (main != null && main.InvokeRequired)
            {                
                this.main.Invoke(new RenderPictureDelegate(new Renderer(picture).RenderPicture));
            }
            else
            {
                new Renderer(picture).RenderPicture();
            }
        }

        public delegate void RenderPictureDelegate();

        public class Renderer
        {
            private readonly IPicture picture;
            public Renderer(IPicture picture)
            {
                this.picture = picture;
            }

            public void RenderPicture()
            {
                FormBoard board = new FormBoard(picture.Width, picture.Height);

                Bitmap bitmap = board.Bitmap;
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0,
                        bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadOnly,
                        PixelFormat.Format32bppArgb);
                unsafe
                {
                    byte* imagePointer1 = (byte*)bitmapData.Scan0;
                    for (int x = 0; x < bitmapData.Width; x++)
                    {
                        for (int y = 0; y < bitmapData.Height; y++)
                        {
                            int color = picture.GetColor(x,y).ToArgb();
                            imagePointer1[0] = (byte)((color & 0xFF0000) >> 16);
                            imagePointer1[1] = (byte)((color & 0xFF00) >> 8);
                            imagePointer1[2] = (byte)((color & 0xFF));
                            imagePointer1[3] = (byte)(0xFF);
                            imagePointer1 += 4;
                        }
                        imagePointer1 += bitmapData.Stride -
                                   (bitmapData.Width * 4);
                    }
                }
                bitmap.UnlockBits(bitmapData);

                Graphics g = Graphics.FromImage(board.Bitmap);
                g.DrawImage(bitmap, new Point(0, 0));
                board.Redraw();
                
                board.Show();                
            }
        }        
    }
}