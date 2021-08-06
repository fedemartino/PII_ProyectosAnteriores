using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TagParser;
using System.Collections;

namespace ExerciseOne
{
    [TestFixture]
    class TestParser
    {
        [TestCase]
        public void parsearNodo()
        {
            String texto = "<html><body><font></font></body></html>";
            XmlParser prueba = new XmlParser();
            ArrayList listaTags = prueba.ParsearTexto(texto);
            Tag primerNodo = (Tag)listaTags[0];
            Tag segundoNodo = (Tag)listaTags[1];
            Tag tercerNodo = (Tag)listaTags[2];
            String nombreNodo1 = primerNodo.Nombre;
            String nombreNodo2 = segundoNodo.Nombre;
            String nombreNodo3 = tercerNodo.Nombre;
            Assert.AreNotEqual (nombreNodo1, "body");
            Assert.AreEqual(nombreNodo1, "html");
            Assert.AreEqual(nombreNodo2, "body");
            Assert.AreEqual(nombreNodo3, "font");
            
        }
        public void parsearAtributo()
        {
            string comillas = '"'.ToString();
            String texto = "<font color=" + comillas + "blue" + comillas + " size=" + comillas + "3" + comillas + ">Ingrese su nombre </font>";
            XmlParser prueba = new XmlParser();
            ArrayList listaTags = prueba.ParsearTexto(texto);
            Tag primerNodo = (Tag)listaTags[0];
            ArrayList listaAtributos = primerNodo.Atributos;
            Atributo primerAtributo = (Atributo)listaAtributos[0];
            Atributo segundoAtributo = (Atributo)listaAtributos[1];
            String nombreAtributo1 = primerAtributo.Nombre;
            String nombreAtributo2 = segundoAtributo.Nombre;
            Assert.AreEqual(nombreAtributo1, "color");
            Assert.AreNotEqual(nombreAtributo1, "size");
            Assert.AreEqual(nombreAtributo2, "size");
            String valorAtributo1 = primerAtributo.Valor;
            String valorArtibuto2 = segundoAtributo.Valor;
            Assert.AreEqual (valorAtributo1, "blue");
            Assert.AreEqual (valorArtibuto2, "3");
        }
    }
}
