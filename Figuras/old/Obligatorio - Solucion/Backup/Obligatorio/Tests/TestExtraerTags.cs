using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Diagnostics;
using System.Collections;

namespace Obligatorio.Tests
{
    /// <summary>
    /// Clase que testea la correcta separación de tags dentro de un texto
    /// </summary>
    [TestFixture]
    public class TestExtraerTags
    {
        /// <summary>
        /// Método que comprueba que se delimiten correctamente los tags
        /// </summary>
        [Test]
        public void TestDelimiTag()
        {
            String texto = "<rotation x=\"65\" y=\"0\" angle=\"90\" figure=\"cuerpo\"/> lalala hola" 
                + "<paint figure=\"sol\" color=\"yellow\"/> esto va a andar si o si!!!";
            ExtraerTags extractor = new ExtraerTags();
            IList<String> listaDeTags = new List<String>();
            listaDeTags = extractor.DelimiTag(texto, listaDeTags);

            Assert.AreEqual(listaDeTags[0], "<rotation x=\"65\" y=\"0\" angle=\"90\" figure=\"cuerpo\"/>");
            Assert.AreEqual(listaDeTags[1], "<paint figure=\"sol\" color=\"yellow\"/>");
        }
    }
}

