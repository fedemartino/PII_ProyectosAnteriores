using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    class FilterEmbossBuilder : FilterBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            FilterEmboss f = new FilterEmboss(ObtenerNombreFiltro(tag.Atributos));
            return f;
        }
    }
}
