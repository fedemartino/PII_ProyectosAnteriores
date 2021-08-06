using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Boolean IsEven(int number)
        {
            return ((number % 2) == 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(numHeight.Value);
            int width = Convert.ToInt32(numWidth.Value);
            Impl.ChessBoard cb = new Impl.ChessBoard(8, 8);
            Gui b = new Gui(width, height, cb);
            //b.Draw(cb);
            b.AddCellSelectListener(new Impl.CellSelectListener(cb, b));
            b.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
