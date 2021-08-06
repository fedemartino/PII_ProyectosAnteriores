using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PicfilLib;
using System.Drawing;

namespace PicEditor.TestCases
{
    [TestFixture]
    class TestPicture
    {
        [TestCase]
        public void CrearPicture()
        {
            Random r = new Random();
            int altura = r.Next(300);
            int ancho = r.Next(300);

            IPicture picture = new Picture(ancho, altura);
            for (int x = 0; x < ancho; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    Assert.AreEqual(picture.GetColor(x, y), Color.Empty);
                }
            }
        }

        [TestCase]
        public void ResizePicture()
        {
            Random r = new Random();
            int alturaInicial = r.Next(300);
            int anchoInicial = r.Next(300);
            IPicture picture = new Picture(anchoInicial, alturaInicial);
            for (int x = 0; x < anchoInicial; x++)
            {
                for (int y = 0; y < alturaInicial; y++)
                {
                    picture.SetColor(x, y, Color.FromArgb(255, 0, 0));
                }
            }
            int nuevaAltura = r.Next(600);
            int nuevoAncho = r.Next(600);

            picture.Resize(nuevoAncho, nuevaAltura);
            for (int x = 0; x < picture.Width; x++)
            {
                for (int y = 0; y < picture.Height; y++)
                {
                    if ((x >= anchoInicial) || (y >= alturaInicial))
                    {
                        Assert.AreEqual(picture.GetColor(x, y), Color.Black);
                    }
                    else 
                    {
                        Assert.AreEqual(picture.GetColor(x, y), Color.FromArgb(255,0,0));
                    }
                }
            }

            

        }
    }
}
