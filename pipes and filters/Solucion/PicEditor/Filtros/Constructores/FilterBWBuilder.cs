using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TagParser;

namespace PicEditor.Filtros.Constructores
{
    class FilterBWBuilder : FilterBuilder
    {
        public override object Build(TagParser.Tag tag, Hashtable hashFiltros)
        {
            FilterBW f = new FilterBW(ObtenerNombreFiltro(tag.Atributos), ObtenerThreshold(tag.Atributos));
            return f;
        }
        private byte ObtenerThreshold(ArrayList atributos)
        {
            byte threshold = 0;
            foreach (Atributo a in atributos)
            {
                if (a.Nombre.ToUpper() == "threshold".ToUpper())
                {
                    threshold = Convert.ToByte(a.Valor);
                }
            }
            return threshold;
        }
    }
}
