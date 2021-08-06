using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using PicEditor.Filtros;
using System.Drawing;
using NUnit.Framework;
using PicEditor.Filtros.Pipes;

namespace PicEditor.TestCases
{
    [TestFixture]
    class TestFiltros
    {
        [TestCase]
        public void FiltroNegativo()
        {
            IPicture picture = new Picture(1, 4);
            picture.SetColor(0, 0, Color.FromArgb(100, 100, 100));
            picture.SetColor(0, 1, Color.FromArgb(0, 100, 0));
            picture.SetColor(0, 2, Color.FromArgb(255, 255, 0));
            picture.SetColor(0, 3, Color.FromArgb(10, 20, 30));
            IFilter filtro = new Filtros.FilterNegative();
            picture = filtro.Filter(picture);
            Assert.AreEqual(picture.GetColor(0, 0), Color.FromArgb(155, 155, 155));
            Assert.AreEqual(picture.GetColor(0, 1), Color.FromArgb(255, 155, 255));
            Assert.AreEqual(picture.GetColor(0, 2), Color.FromArgb(0, 0, 255));
            Assert.AreEqual(picture.GetColor(0, 3), Color.FromArgb(245, 235, 225));
        }

        [TestCase]
        public void TestBlancoNegro()
        {
            Random r = new Random();
            int ancho = r.Next(400);
            int alto = r.Next(400);

            IPicture p = new Picture(ancho, alto);
            IFilter bw = new FilterBW(100);
            
            for (int x = 0; x < p.Width; x++)
            {
                for (int y = 0; y < p.Height; y++)
                {
                    p.SetColor(x, y, Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)));
                }
            }
            
            IPicture pFiltrado = p.Clone();
            pFiltrado = bw.Filter(p);

            for (int x = 0; x < p.Width; x++)
            {
                for (int y = 0; y < p.Height; y++)
                {
                    Color colorActual = p.GetColor(x,y);
                    int maxColor = Math.Max(colorActual.B,
                                            Math.Max(colorActual.R, colorActual.G));
                    if (maxColor > 100)
                    {
                        Assert.AreEqual(Color.White, pFiltrado.GetColor(x, y));
                    }
                    else
                    {
                        Assert.AreEqual(Color.Black, pFiltrado.GetColor(x, y));
                    }
                }
            }


        }
        [TestCase]
        public void TestBlurFilter() 
        {
            Random r = new Random();
            int ancho = r.Next(20,400);
            int alto = r.Next(20, 400);

            IPicture p = new Picture(ancho, alto);
            IFilter blur = new FilterBlur();

            for (int x = 0; x < p.Width; x++)
            {
                for (int y = 0; y < p.Height; y++)
                {
                    p.SetColor(x, y, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
                }
            }

            IPicture pFiltrado = p.Clone();
            pFiltrado = blur.Filter(p);
            int xRand, yRand;
            int rPrueba = 0;
            int gPrueba = 0;
            int bPrueba = 0;
            Color colorActual;

            for (int cantidad = 0; cantidad < 100; cantidad++)
            {
                
                xRand = r.Next(2, p.Width - 3);
                yRand = r.Next(2, p.Height - 3);
                rPrueba = 0;
                gPrueba = 0;
                bPrueba = 0;
                                
                for (int a = -1; a < 2; a++)
                {
                    for (int b = -1; b < 2; b++)
                    {
                        colorActual = p.GetColor(xRand + a, yRand + b);
                        rPrueba = rPrueba + colorActual.R;
                        gPrueba = gPrueba + colorActual.G;
                        bPrueba = bPrueba + colorActual.B;
                    }

                }
                rPrueba = rPrueba / 9;
                gPrueba = gPrueba / 9;
                bPrueba = bPrueba / 9;
                Assert.AreEqual(pFiltrado.GetColor(xRand, yRand), Color.FromArgb(rPrueba, gPrueba, bPrueba));
            }


        }
        [TestCase]
        public void TestEmbossFilter()
        {
            Random r = new Random();
            int ancho = r.Next(20, 400);
            int alto = r.Next(20, 400);

            IPicture p = new Picture(ancho, alto);
            IFilter emboss = new FilterEmboss();

            for (int x = 0; x < p.Width; x++)
            {
                for (int y = 0; y < p.Height; y++)
                {
                    p.SetColor(x, y, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
                }
            }

            IPicture pFiltrado = p.Clone();
            pFiltrado = emboss.Filter(p);
            int xRand, yRand;
            int rPrueba = 0;
            int gPrueba = 0;
            int bPrueba = 0;
            Color colorActual;
            Color colorCentro;

            for (int cantidad = 0; cantidad < 100; cantidad++)
            {

                xRand = r.Next(2, p.Width - 3);
                yRand = r.Next(2, p.Height - 3);
                rPrueba = 0;
                gPrueba = 0;
                bPrueba = 0;
                colorCentro = p.GetColor(xRand, yRand);
                rPrueba = colorCentro.R * 4;
                gPrueba = colorCentro.G * 4;
                bPrueba = colorCentro.B * 4;

                for (int a = -1; a < 2; a+=2)
                {
                    for (int b = -1; b < 2; b+=2)
                    {
                        colorActual = p.GetColor(xRand + a, yRand + b);
                        rPrueba = rPrueba - colorActual.R;
                        gPrueba = gPrueba - colorActual.G;
                        bPrueba = bPrueba - colorActual.B;
                    }

                }
                rPrueba = Math.Min(Math.Abs(rPrueba + 127), 255);
                gPrueba = Math.Min(Math.Abs(gPrueba + 127), 255);
                bPrueba = Math.Min(Math.Abs(bPrueba + 127), 255);
                Assert.AreEqual(pFiltrado.GetColor(xRand, yRand), Color.FromArgb(rPrueba, gPrueba, bPrueba));
            }


        }
        [TestCase]
        public void TestFilterPipe()
        {
            IPicture imagen = new Picture(1, 4);
            DummyPipe extremoUno = new DummyPipe("Dummy");
            FilterPipe filtro = new FilterPipe(extremoUno);
            filtro.Filter(imagen);
            Assert.AreEqual(extremoUno.Verificacion, true);           
        }
        [TestCase]
        public void TestFilterRender()
        {
            Random aleatorio = new Random();
            IPicture imagen = new Picture(20, 30);
            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    imagen.SetColor(x, y, Color.FromArgb(aleatorio.Next(255), aleatorio.Next(255), aleatorio.Next(255)));
                }
            }
            DummyRender desplegador = new DummyRender();
            FilterRender filtro = new FilterRender(desplegador);
            filtro.Filter(imagen);
            Assert.AreEqual(desplegador.Verificacion, true);
        }
    }
}
