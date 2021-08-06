using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections;


namespace POO.Libreria
{
    public class XmlParser
    {
        /// <summary>
        /// Utiliza el XML Parser para convertir el string en una coleccion de tags
        /// </summary>
        /// <param name="texto">String con los tags y atributos a parsear</param>
        public void ParsearTexto(String texto)
        {
            //Creo un documento XML. El Parser XML de .NET se encarga de crear nodos y atributos
            XmlDocument doc = new XmlDocument();
            ArrayList ListaTags = new ArrayList();
            //Tag tagAuxiliar;

            //Leo el string pasado como parametro y lo convierto a un documento XML
            doc.LoadXml(texto);
            //Tomo el primer nodo del documento XML y lo parseo
            XmlNode nodo = doc.FirstChild;
            ParsearNodos(nodo);
        }
        /// <summary>
        /// Metodo recursivo para recorrer el documento XML.
        /// </summary>
        /// <param name="root"> Nodo raiz del documento</param>
        private void ParsearNodos(XmlNode root)
        { 
            //Se obtienen una lista de atributos del nodo. 
             ParsearAtributos(root);
            //Estos deberan ser almacenados junto al tag correspondiente y el 
            //tag deberá ser almacenado en una estructura adecuada
           
            if ((root.FirstChild != null) && (root.FirstChild.NodeType == XmlNodeType.Element))
            {
               //Se parsea el siguiente nodo de la lista
               ParsearNodos(root.FirstChild);
            }
            if (root.NextSibling != null)
            {
               //Se parsea el siguiente nodo de la lista
               ParsearNodos(root.NextSibling);
            }
        }
        /// <summary>
        /// Parsea los atributos de un nodo XML en particular
        /// </summary>
        /// <param name="nodo">nodo a parsear</param>
        /// <returns>Lista de atributos</returns>
        private ArrayList ParsearAtributos(XmlNode nodo)
        {
            ArrayList listaAtributos = new ArrayList();
            XmlAttributeCollection atr = nodo.Attributes;
            if (atr != null)
            {
                foreach (XmlAttribute a in atr)
                {
                    //Código para instanciar un nuevo atributo y almacenarlo en una lista
                    //listaAtributos.Add(atributo);
                }
            }
            return listaAtributos;
        }
    }
}
