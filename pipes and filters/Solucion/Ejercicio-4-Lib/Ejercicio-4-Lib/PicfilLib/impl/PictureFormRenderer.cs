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
    /// Despliega imagenes en un formulario nuevo o en uno existente.
    /// </summary>
    public class PictureFormRenderer : IPictureRenderer
    {
        private readonly Form main;
        private readonly FormBoard destination;

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre un nuevo formulario.        
        /// </summary>
        /// <remarks>
        /// Para usar este metodo es fundamental que el bucle de eventos de la aplicacion
        /// no se haya iniciado. Esto significa, que no se haya llamado a Application.Run() 
        /// o similar.
        /// </remarks>
        public PictureFormRenderer()
        {
            this.main = null;
        }

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre un nuevo formulario.
        /// </summary>
        /// <param name="main">la ventana principal de la aplicacion</param>
        public PictureFormRenderer(Form main)
        {
            Debug.Assert(main != null, "El formulario principal no debe ser nulo");
            
            this.main = main;
        }

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre el formulario de destinto
        /// pasado como argumento.
        /// </summary>
        /// <param name="main">la ventana principal de la aplicacion</param>
        /// <param name="destination">el formulario de destino</param>
        public PictureFormRenderer(Form main, FormBoard destination)
        {
            Debug.Assert(main != null, "El formulario principal no debe ser nulo");
            Debug.Assert(destination != null, "El formulario de destino no debe ser nulo");

            this.main = main;
            this.destination = destination;
        }

        /// <summary>
        /// Despliega la imagen.
        /// </summary>
        /// <param name="picture">la imagen a desplegar</param>
        public void Render(IPicture picture)
        {
            Debug.Assert(picture != null, "La imagen a desplegar no debe ser nulo");

            Bitmap bitmap = GetBitmap(picture);
            if (main != null && main.InvokeRequired)
            {
                this.main.Invoke(new RenderPictureDelegate(new Renderer(bitmap, destination).RenderPicture));
            }
            else
            {
                new Renderer(bitmap, destination).RenderPicture();
            }
        }

        private Bitmap GetBitmap(IPicture picture)
        {
            Bitmap bitmap = new Bitmap(picture.Width-10, picture.Height-10);
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
            return bitmap;
        }
       
        public delegate void RenderPictureDelegate();

        public class Renderer
        {
            private readonly Bitmap bitmap;
            private readonly FormBoard destination;

            public Renderer(Bitmap bitmap, FormBoard destination)
            {
                this.bitmap = bitmap;
                this.destination = destination;
            }

            public void RenderPicture()
            {
                FormBoard board = (destination == null 
                    ? new FormBoard(bitmap.Width, bitmap.Height) : destination);
                
                Graphics g = Graphics.FromImage(board.Bitmap);
                g.Clear(board.BackColor);
                g.DrawImage(bitmap, new Point(0, 0));
                board.Redraw();
                
                board.Show();                
            }
        }        
    }
}