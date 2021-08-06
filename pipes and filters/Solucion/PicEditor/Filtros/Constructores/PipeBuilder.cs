using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TagParser;

namespace PicEditor.Filtros.Constructores
{
    abstract class PipeBuilder : ITagBuilder
    {
        public abstract object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros);

        public void BuildAndPersist(TagParser.Tag tag, ref System.Collections.Hashtable hashFiltros)
        {
            hashFiltros.Add(ObtenerNombrePipe(tag.Atributos), Build(tag, hashFiltros));
        }
        protected string ObtenerNombrePipe(ArrayList atributos)
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

    }
}
