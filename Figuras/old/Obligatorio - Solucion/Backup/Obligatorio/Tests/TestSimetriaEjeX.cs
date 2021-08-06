using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Diagnostics;

namespace Obligatorio.Tests
{
    /// <summary>
    /// Clase que testa la simetria de eje X.
    /// </summary>
    [TestFixture]
    public class TestSimetriaEjeX
    {
        /// <summary>
        /// Método que comprueba el correcto funcionamiento de la simetria de eje X.
        /// </summary>
        [Test]
        public void TestHacerTransformacion()
        {
            IPoint[] original = new Coordenadas[2];
            original[0] = new Coordenadas(1, 1);
            original[1] = new Coordenadas(2, 2);

            Int32 ejeSimetria = 4;
            ITransformacion miSimetria = new SimetriaEjeX(ejeSimetria);
            IPoint[] simetrizado = miSimetria.HacerTransformacion(original);

            Assert.AreEqual(simetrizado[0].X, 7);
            Assert.AreEqual(simetrizado[0].Y, 1);
            Assert.AreEqual(simetrizado[1].X, 6);
            Assert.AreEqual(simetrizado[1].Y, 2);            
        }
    }
}
