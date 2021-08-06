using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    class FilterBlurBuilder : FilterBuilder
    {

        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            FilterBlur f = new FilterBlur(ObtenerNombreFiltro(tag.Atributos));
            return f;
        }
    }
}
