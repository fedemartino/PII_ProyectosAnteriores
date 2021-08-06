using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    class FilterGreyscaleBuilder : FilterBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            FilterGreyscale f = new FilterGreyscale(ObtenerNombreFiltro(tag.Atributos));
            return f;
        }
    }
}
