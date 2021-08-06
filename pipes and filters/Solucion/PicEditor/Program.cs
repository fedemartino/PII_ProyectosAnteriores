using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PicfilLib;
using System.IO;
using System.Reflection;
using TagParser;
using PicEditor.Filtros;
using System.Collections;


namespace PicEditor
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region ejeccución en Form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSelector());
            #endregion
        }
    }
}
