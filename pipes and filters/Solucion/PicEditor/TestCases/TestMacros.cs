using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using NUnit.Framework;
using PicEditor.Macros;
using System.Drawing;
using PicEditor.Filtros;

namespace PicEditor.TestCases
{
    [TestFixture]
    class TestMacros
    {
        [TestCase]
        public void TestMacro()
        {
            Random aleatorio = new Random();
            IPicture imagen = new Picture(1, 4);
            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    imagen.SetColor(x, y, Color.FromArgb(aleatorio.Next(255), aleatorio.Next(255), aleatorio.Next(255)));
                }
            }
            IPicture imagenClon = imagen.Clone();
            IFilter bw = new FilterBW();
            IFilter emboss = new FilterEmboss();
            imagen = bw.Filter(imagen);
            imagen = emboss.Filter(imagen);
            Macro macro = new Macro("macroTest");
            macro.AddStep(emboss);
            macro.AddStep(bw);
            imagenClon = macro.Filter(imagenClon);
            for (int j = 0; j < imagen.Width; j++)
                for (int q = 0; q < imagen.Height; q++)
                {
                    Assert.AreEqual(imagen.GetColor(j, q), imagenClon.GetColor(j, q));
                    Assert.AreEqual(imagen.GetColor(j, q), imagenClon.GetColor(j, q));
                    Assert.AreEqual(imagen.GetColor(j, q), imagenClon.GetColor(j, q));
                }
        }
    }
}
