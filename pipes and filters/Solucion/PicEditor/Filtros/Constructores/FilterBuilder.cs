using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagParser;
using System.Collections;
using System.Diagnostics;

namespace PicEditor.Filtros.Constructores
{
    abstract class FilterBuilder : ITagBuilder
    {
        public abstract object Build(TagParser.Tag tag, Hashtable hashFiltros);

        protected string ObtenerNombreFiltro(ArrayList atributos)
        {
            string nombre = "";
            foreach (Atributo a in atributos)
            {
                if (a.Nombre.ToUpper() == "name".ToUpper())
                {
                    nombre = a.Valor;
                }
            }
            return nombre;
        }
        /// <summary>
        /// Construye el filtro adecuado a partir del tag y lo almacena en el hash table de filtros
        /// </summary>
        /// <param name="tag">tag con la información del filtro</param>
        /// <param name="hashFiltros">hash table con filtros</param>
        /// <param name="hashPipes">hash table con Pipes</param>
        public void BuildAndPersist(Tag tag, ref Hashtable hashFiltros)
        {
            Debug.Assert(!hashFiltros.Contains(ObtenerNombreFiltro(tag.Atributos)));
            hashFiltros.Add(ObtenerNombreFiltro(tag.Atributos), Build(tag, hashFiltros));
        }
    }
}
