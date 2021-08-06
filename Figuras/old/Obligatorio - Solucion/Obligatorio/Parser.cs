using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Obligatorio
{   
    /// <summary>
    /// Esta Clase tiene la responsabilidad de buscar el nombre y los atributos, con su valor 
    /// correspondiente, dentro de determinado tag. 
    /// Debe conocer los caracteres con los que se delimitan las distintas partes que conforman 
    /// un tag. 
    /// </summary>
    public class Parser
    {
      
        IList<Tags> res = new List<Tags>();
        private char openTag = '<';
        private char barra = '/';
        private char closeTag = '>';
        private char blanco = ' ';
        private char esIgual = '=';
        private char comillas = '"';
        
        /// <summary>
        /// Método que se encarga de extraer el nombre de determinado tag. Luego manda el
        /// tag a el método ObtenerAtributos. Al Finalizar guarda el nombre y los atributos 
        /// del tag en un objeto de la clase Tags.
        /// </summary>
        /// <param name="tagList">
        /// tag: String del que se van a extraer los atributos.
        /// </param>
        public IList<Tags> TagParser(IList<String> tagList)
        {

            foreach (String tag in tagList)
            {
                String nombreTag;
                Tags info;
                Hashtable atributos = new Hashtable();
                int posOpenTag = tag.IndexOf(openTag, 0);
                int posBarra = tag.IndexOf(barra, 0);
                int posCloseTag = tag.IndexOf(closeTag, 0);
                int posEsIgual = tag.IndexOf(esIgual, 0);
                int posBlanco = tag.IndexOf(blanco, 0);
                

                // obtengo el nombre del tag y lo guardo en un objeto de clase Tags.
                if (posEsIgual == -1) // Caso particular en el que el tag no tiene atributos.
                    if (posCloseTag < posBarra) // Si el tag es de la forma <nombre> comentario </nombre>.
                        nombreTag = (tag.Substring(posOpenTag + 1, posCloseTag - posOpenTag - 1)).Trim();
                    
                    else // Si el tag es de la forma <nombre/>. 
                        nombreTag = (tag.Substring(posOpenTag + 1, posBarra - posOpenTag - 1)).Trim();
                else // Caso general en que el tag esta completo, con todos sus elementos.
                {
                    nombreTag = (tag.Substring(posOpenTag + 1, posBlanco - posOpenTag - 1)).Trim();
                    atributos = ObtenerAtributos(tag,nombreTag,atributos);       
                }
                info = new Tags(nombreTag,atributos);
                res.Add(info); 
            }
            return res;
        }
        
        /// <summary>
        /// Método que se encarga de tomar los atributos y su valor, desde un tag que se le pasa
        /// por parámetro. Luego los devuelve dentro de una Hashtable.
        /// </summary>
        /// <param name="atributos">Hashtable donde se van a guardar los atributos.</param>
        /// <param name="nombreTag">Nombre del tag</param>
        /// <param name="tag">String del que se van a extraer los atributos.</param>
        private Hashtable ObtenerAtributos(String tag, String nombreTag, Hashtable atributos){
                
            String atributo = "";
            String valor="";
            int contador = 0;
            while (contador < tag.LastIndexOf(comillas))
            {
                int posEsIgual = tag.IndexOf(esIgual, contador);
                int posBlanco = tag.IndexOf(blanco, contador);
                int posAbrirComillas = tag.IndexOf(comillas, contador);
                int posCerrarComillas = tag.IndexOf(comillas, posAbrirComillas + 1);
                atributo = (tag.Substring(posBlanco, posEsIgual - posBlanco)).Trim();
                valor = (tag.Substring(posAbrirComillas + 1, posCerrarComillas - posAbrirComillas - 1)).Trim();
                if (!(atributos.ContainsKey(atributo))) // Si el atributo no se encuentra en la Hash, se agrega.
                    atributos.Add(atributo, valor);
                else{ }
                contador = posCerrarComillas + 1;
            }
            return atributos;
        }

        /// <summary>
        /// Separa palabras de un String que se le es pasado por parámetro.
        /// </summary>
        /// <param name="comp">Palabras separadas por espacios.</param>
        /// <returns>Lista de palabras contenidas en un String.</returns>
        public String[] ParsearAtributos(String texto)
        {
            Char delimitador = ' ';
            String[] componentes = texto.Split(delimitador);
            return componentes;
        }
    }
}