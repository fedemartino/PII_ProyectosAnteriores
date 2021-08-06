using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    interface ITagBuilder
    {
        /// <summary>
        /// Construye un Objeto nuevo a partir de un tag
        /// </summary>
        /// <param name="tag">Tag con los datos del objeto</param>
        /// <param name="hashFiltros">Hash con todos los filtros creados hasta el momento</param>
        /// <param name="hashPipes">Hash con todos los pipes creados hasta el momento</param>
        /// <returns>Objeto creado</returns>
        Object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros);
        /// <summary>
        /// Construye un Objeto nuevo a partir de un tag y lo guarda en el hashtable correspondiente
        /// </summary>
        /// <param name="tag">Tag con los datos del objeto</param>
        /// <param name="hashFiltros">Hash con todos los filtros creados hasta el momento</param>
        /// <param name="hashPipes">Hash con todos los pipes creados hasta el momento</param>
        void BuildAndPersist(TagParser.Tag tag, ref System.Collections.Hashtable hashFiltros);
    }
}
