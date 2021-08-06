using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Obligatorio
{
    /// <summary>
    /// Esta clase tiene la responsabilidad de buscar los tags que se encuentran dentro de
    /// un texto.
    /// Debe conocer los caracteres con los que se delimitan los tags.
    /// </summary>
    public class ExtraerTags
    {
        private int posOpenTag;
        private int posBarra;
        private int posCloseTag;
        
        /// <summary>
        /// Método que se encarga de extraer los tags de determinado texto que se le es
        /// pasado por parámetro.
        /// </summary>
        /// <param name="texto">String del que se van a extraer los tags.</param>
        /// <param name="tagList">Lista con los tags leidos desde el archivo.</param>
        /// <returns>Lista con los tags extraidos.</returns>
        public IList<String> DelimiTag(String texto, IList<String> tagList)
        {
            int i = 0;
            while (i < texto.LastIndexOf(">"))
            {
                posOpenTag = texto.IndexOf("<", i);
                posBarra = texto.IndexOf("/", i);
                posCloseTag = texto.IndexOf(">", posBarra);
                tagList.Add(texto.Substring(posOpenTag, posCloseTag - posOpenTag + 1));
                i = posCloseTag;
            }
            return tagList;
        }
    }
}
