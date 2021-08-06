using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicfilLib
{
    /// <summary>
    /// Muestra un dialogo para ingresar el nombre de un macro.
    /// </summary>
    public partial class RecordMacroDialog : Form
    {
        private String macroName;

        public RecordMacroDialog()
        {
            InitializeComponent();
        }

        public String MacroName { get { return macroName; } }

        private void okBtn_Click(object sender, EventArgs e)
        {
            AcceptDialog();
        }

        private void AcceptDialog()
        {
            macroName = macroNameText.Text;            
            Close();
        }      
    }
}