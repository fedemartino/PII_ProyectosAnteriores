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
    class TestPipes
    {
        [TestCase]
        public void TestFork()
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
            DummyPipe extremoUno = new DummyPipe("Dummy");
            DummyPipe extremoDos = new DummyPipe("DummyUno");
            PipeFork fork = new PipeFork("hola", extremoUno, extremoDos);
            fork.Send(imagen);            
            Assert.AreEqual(extremoUno.Verificacion, true);            
            Assert.AreEqual(extremoDos.Verificacion, true);
            for (int j = 0; j < extremoDos.Imagen.Width; j++)
                for (int q = 0; q < extremoDos.Imagen.Height; q++)
                {
                    Assert.AreEqual(imagen.GetColor(j,q),extremoDos.Imagen.GetColor(j,q));
                    Assert.AreEqual(imagen.GetColor(j, q), extremoUno.Imagen.GetColor(j, q));
                    Assert.AreEqual(extremoUno.Imagen.GetColor(j, q), extremoDos.Imagen.GetColor(j, q));
                }
                               
        }

        public void TestSerial()
        {            
            Random aleatorio = new Random();
            IPicture imagen = new Picture(10, 40);
            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    imagen.SetColor(x, y, Color.FromArgb(aleatorio.Next(255), aleatorio.Next(255), aleatorio.Next(255)));
                }
            }
            DummyPipe extremoUno = new DummyPipe("Dummy");
            FilterBlur filtro = new FilterBlur();
            PipeSerial serial = new PipeSerial("hola", filtro, extremoUno);
            serial.Send(imagen);
            Assert.AreEqual(extremoUno.Verificacion, true);  
            for (int j = 0; j < extremoUno.Imagen.Width; j++)
                for (int q = 0; q < extremoUno.Imagen.Height; q++)
                {
                    Assert.AreNotEqual(imagen.GetColor(j, q), extremoUno.Imagen.GetColor(j, q));                  
                }                      
        }
    }
}
