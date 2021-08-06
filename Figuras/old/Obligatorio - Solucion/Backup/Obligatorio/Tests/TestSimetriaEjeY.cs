using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Diagnostics;

namespace Obligatorio.Tests
{
    /// <summary>
    /// Clase que testa la simetria de eje Y.
    /// </summary>
    [TestFixture]
    public class TestSimetriaEjeY
    {
        /// <summary>
        /// Método que comprueba el correcto funcionamiento de la simetria de eje Y.
        /// </summary>
        [Test]
        public void TestHacerTransformacion()
        {

            IPoint[] original = new Coordenadas[2];
            original[0] = new Coordenadas(1, 1);
            original[1] = new Coordenadas(2, 2);

            Int32 ejeSimetria = 4;
            ITransformacion miSimetria = new SimetriaEjeY(ejeSimetria);
            IPoint[] simetrizado = miSimetria.HacerTransformacion(original);

            Assert.AreEqual(simetrizado[0].X, 1);
            Assert.AreEqual(simetrizado[0].Y, 7);
            Assert.AreEqual(simetrizado[1].X, 2);
            Assert.AreEqual(simetrizado[1].Y, 6);
        }
    }
}

