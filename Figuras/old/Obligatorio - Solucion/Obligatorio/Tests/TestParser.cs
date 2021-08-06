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
    /// Clase que testea la correcta separación de nombre y atributos dentro de un tag
    /// </summary>
    [TestFixture]
    public class TestParser
    {
        Parser parseador = new Parser();

        /// <summary>
        /// Método que comprueba que a partir de los datos del tag en un string,
        /// se cree un elemento del tipo Tag con el nombre y los atributos correspondientes.
        /// </summary>
        [Test]
        public void TestTagParser()
        {
            IList<String> tag = new List<String>();
            tag.Add("<pepe telefono=\"01234\" ci=\"5678\"/>");
            
            IList<Tags> res = new List<Tags>();
            res = parseador.TagParser(tag);
            Assert.AreEqual(res[0].Nombre, "pepe");
            Assert.AreEqual((res[0].Atributos)["telefono"], "01234");
            Assert.AreEqual((res[0].Atributos)["ci"], "5678");
        }

        /// <summary>
        /// Método que comprueba que a partir de un texto cualquiera, el mismo se separe por espacios,
        /// almacenándose en un array de strings
        /// </summary>
        [Test]
        public void TestParsearAtributos()
        {
            String texto = "<paint figure=\"sol\" color=\"yellow\"/> ";
            IList<String> atributos = new List<String>();            
            atributos = parseador.ParsearAtributos(texto);

            Assert.AreEqual(atributos[0], "<paint");
            Assert.AreEqual(atributos[1], "figure=\"sol\"");
            Assert.AreEqual(atributos[2], "color=\"yellow\"/>");
        }
    }
}
