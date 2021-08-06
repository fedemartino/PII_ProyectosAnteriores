using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TagParser;

namespace Tests
{
    [TestFixture]
    class TestAtributos
    {
        [TestCase]
        public void CrearAtributo()
        {
            Atributo a = new Atributo("prueba1", "valor1");
            Assert.AreEqual(a.Nombre, "prueba1");
            Assert.AreEqual(a.Valor, "valor1");

            Atributo b = new Atributo("prueba1", "valor1");
            Assert.AreNotEqual(a, b);
        }
    }
}
