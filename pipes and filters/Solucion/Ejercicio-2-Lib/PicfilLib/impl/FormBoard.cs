using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace PicfilLib
{
    public partial class FormBoard : Form
    {
        private Bitmap bitmap;

        public Bitmap Bitmap { get { return bitmap; } }

        public FormBoard(int width, int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.bitmap = new Bitmap(width, height);
        }

        public void Redraw()
        {
            this.Invalidate();
        }
        
        private void FormBoard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
        }
        
        private void FormBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            bitmap.Dispose();
        }
    }
}