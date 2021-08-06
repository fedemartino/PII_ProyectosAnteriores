using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Diagnostics;

namespace Obligatorio.Tests
{
    /// <summary>
    /// Clase que testa la traslacion.
    /// </summary>
    [TestFixture]
    public class TestTraslacion
    {
        /// <summary>
        /// Método que comprueba el correcto funcionamiento de la traslacion.
        /// </summary>
        [Test]
        public void TestHacerTransformacion()
        {

            IPoint[] original = new Coordenadas[2];
            original[0] = new Coordenadas(1, 1);
            original[1] = new Coordenadas(2, 2);

            ITransformacion miTraslacion = new Traslacion(2, 2);
            IPoint[] trasladado = miTraslacion.HacerTransformacion(original);

            Assert.AreEqual(3, trasladado[0].X);
            Assert.AreEqual(3, trasladado[0].Y);
            Assert.AreEqual(4, trasladado[1].X);
            Assert.AreEqual(4, trasladado[1].Y);
        }

    }
}


