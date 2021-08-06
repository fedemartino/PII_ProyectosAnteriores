using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Imaging;
using System.Threading;

namespace PainterLib
{
    /// <summary>
    /// Ventana que muestra el estado de una pizzarra.
    /// </summary>
    /// <remarks>
    /// El tamaño de los pixeles usados para dibujar es determinado por el ancho y alto de la
    /// ventana y el alto y ancho de la pizzarra. Es decir, si la ventana es de 800x800 y la pizarra
    /// de 400x400, se asumira que cada punto de la pizarra en realidad ocupa 2x2 pixeles.
    /// </remarks>
    public partial class FormBoard : Form, IGui
    {
        private Boolean closing = false;
        private Bitmap bitmap;
        private Int32 xPixelSize;
        protected Int32 XPixelSize { get { return xPixelSize; } }        
        
        private Int32 yPixelSize;
        protected Int32 YPixelSize { get { return yPixelSize; } }

        private Int32 boardWidth;
        protected Int32 BoardWidth { get { return boardWidth; } }

        private Int32 boardHeight;
        protected Int32 BoardHeight { get { return boardHeight; } }

        private IBoard lastBoard;
        protected IBoard LastBoard { get { return lastBoard; } }      
        
        /// <summary>
        /// Construye una nueva ventana que muestra la pizarra 
        /// pasada por parámetro
        /// </summary>
        /// <param name="model">La pizarra a mostrar.</param>
        public FormBoard(Int32 width, Int32 height)
        {
            Debug.Assert(width > 0);
            Debug.Assert(height > 0);

            this.Width = width+50;
            this.Height = height+50;                        
            
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Muestra la ventana para mostrar la pizarra.
        /// </summary>
        public void Open()
        {
            Show();
        }

        /// <summary>
        /// Retorna si la ventana para mostrar la pizarra es visible.
        /// </summary>
        /// <returns><code>True</code> si la ventana es visible</returns>
        public Boolean IsOpen()
        {
            return this.Visible;
        }       

        /// <summary>
        /// Dibuja la pizarra pasada por parametro.
        /// </summary>
        /// <param name="board">la pizarra</param>
        public void Redraw(IBoard board)
        {
            Debug.Assert(board != null);

            if (!closing && !IsDisposed && Visible && !ClientRectangle.Size.IsEmpty)
            {
                this.lastBoard = board;
                this.bitmap = GetBitmap(board);
                try
                {
                    if (InvokeRequired)
                    {
                        Invoke(new ExecuteActionDelegate(RedrawBitmap));
                    }
                    else
                    {
                        RedrawBitmap();
                    }
                }
                catch (ThreadInterruptedException)
                {
                }
            }            
        }

        
        private delegate void ExecuteActionDelegate();
        private void RedrawBitmap()
        {
            Invalidate();
            Update();
        }
        
        private void Refresh(Graphics graphics)
        {
            Debug.Assert(graphics != null, "Null graphics");

            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            
            if (bitmap != null && Visible && !ClientRectangle.Size.IsEmpty)
            {
                
                graphics.DrawImage(bitmap, new System.Drawing.Point(0, 0));                    
            }            
        }       
        
        private Bitmap GetBitmap(IBoard board)
        {
            Debug.Assert(board != null);

            Bitmap bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0,
                    bitmap.Width, bitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);
            
            Int32 bitsPerPixel = 4;
            Int32 offset = bitmapData.Stride - (bitmapData.Width * bitsPerPixel);

            boardWidth = board.MaxX;
            boardHeight = board.MaxY;
            yPixelSize = Math.Max(1, ClientRectangle.Height / boardHeight);
            xPixelSize = Math.Max(1, ClientRectangle.Width / boardWidth);            
            unsafe
            {                
                    byte* imagePointer1 = (byte*)bitmapData.Scan0;
                    Int32 boardY = 0;
                    for (int y = 0; y < bitmapData.Height; y++)
                    {                        
                        boardY = y / yPixelSize;                        
                        for (int x = 0; x < bitmapData.Width; x++)
                        {
                            Int32 boardX = x / xPixelSize;
                            if (board.IsPainted(boardX, boardY))
                            {                                    
                                UInt32 color = board.GetColor(boardX, boardY).ToArgb();
                                imagePointer1[0] = (byte)(color & 0xFF);
                                imagePointer1[1] = (byte)((color >> 8) & 0xFF);
                                imagePointer1[2] = (byte)((color >> 16) & 0xFF);
                                imagePointer1[3] = (byte)((color >> 24) & 0xFF);
                            }
                            else
                            {
                                imagePointer1[0] = 0x00;
                                imagePointer1[1] = 0x00;
                                imagePointer1[2] = 0x00;                                
                                imagePointer1[3] = 0xFF;
                            }                            
                            imagePointer1 += bitsPerPixel;
                        }
                        imagePointer1 += offset;
                    }                
            }
            bitmap.UnlockBits(bitmapData);

            Debug.Assert(bitmap != null);

            return bitmap;
        }

        #region eventhandlers

        private void FormBoard_Paint(object sender, PaintEventArgs e)
        {
            Debug.Assert(sender != null, "Null sender");
            Debug.Assert(e != null, "Null event");

            Refresh(e.Graphics);
        }        

        private void FormBoard_Resize(object sender, EventArgs e)
        {
            if (lastBoard != null)
            {
                Redraw(lastBoard);
            }
        }
        
        private void FormBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closing = true;
        }

        #endregion        
    }

}