using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections;


namespace TagParser
{
    public class XmlParser
    {
        /// <summary>
        /// Utiliza el XML Parser para convertir el string en una coleccion de tags
        /// </summary>
        /// <param name="texto">String con los tags y atributos a parsear</param>
        /// <returns>Lista de tags</returns>
        public ArrayList ParsearTexto(String texto)
        {
            //Creo un documento XML. El Parser XML de .NET se encarga de crear nodos y atributos
            XmlDocument doc = new XmlDocument();
            ArrayList ListaTags = new ArrayList();
            //Tag tagAuxiliar;

            //Leo el string pasado como parametro y lo convierto a un documento XML
            doc.LoadXml(texto);
            //Tomo el primer nodo del documento XML y lo parseo
            XmlNode nodo = doc.FirstChild;
            ListaTags = ParsearNodos(nodo);

            return ListaTags;
        }
        /// <summary>
        /// Metodo recursivo para recorrer el documento XML.
        /// </summary>
        /// <param name="root"> Nodo raiz del documento</param>
        /// <returns>Lista de tags</returns>
        private ArrayList ParsearNodos(XmlNode root)
        {
            ArrayList listaTags = new ArrayList();
            
            Tag tagAuxiliar = new Tag(root.Name);
            listaTags.Add(tagAuxiliar);
            tagAuxiliar.Atributos = ParsearAtributos(root);

            if ((root.FirstChild != null) && (root.FirstChild.NodeType == XmlNodeType.Element))
            {
               listaTags.AddRange(ParsearNodos(root.FirstChild));
            }
            if (root.NextSibling != null)
            {                 
               listaTags.AddRange(ParsearNodos(root.NextSibling));
            }
            return listaTags;
        }
        /// <summary>
        /// Parsea los atributos de un nodo XML en particular
        /// </summary>
        /// <param name="nodo">nodo a parsear</param>
        /// <returns>Lista de atributos</returns>
        private ArrayList ParsearAtributos(XmlNode nodo)
        {
            ArrayList listaAtributos = new ArrayList();
            Atributo atributo;
            XmlAttributeCollection atr = nodo.Attributes;
            if (atr != null)
            {
                foreach (XmlAttribute a in atr)
                {
                    atributo = new Atributo(a.Name, a.Value);
                    listaAtributos.Add(atributo);
                }
            }
            return listaAtributos;
        }
    }
}
