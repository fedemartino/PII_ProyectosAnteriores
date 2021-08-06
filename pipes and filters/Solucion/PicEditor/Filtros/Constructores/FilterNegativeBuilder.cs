using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    class FilterNegativeBuilder : FilterBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            FilterNegative f = new FilterNegative(ObtenerNombreFiltro(tag.Atributos));
            return f;
        }
    }
}
