using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Diagnostics;

namespace Obligatorio.Tests
{
    /// <summary>
    /// Clase que testa la rotacion.
    /// </summary>
    [TestFixture]
    public class TestRotacion
    {
        /// <summary>
        /// Método que comprueba el correcto funcionamiento de la rotacion.
        /// </summary>
        [Test]
        public void TestHacerTransformacion()
        {
            IPoint[] original = new Coordenadas[2];
            original[0] = new Coordenadas(1, 1);
            original[1] = new Coordenadas(2, 1);

            ITransformacion miRotacion = new Rotacion(2, 1, 180);
            IPoint[] rotado = miRotacion.HacerTransformacion(original);

            Assert.AreEqual(rotado[0].X, 3);
            Assert.AreEqual(rotado[0].Y, 1);
            Assert.AreEqual(rotado[1].X, 2);
            Assert.AreEqual(rotado[1].Y, 1);        
        }
    }
}