using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PicfilLib;
using TagParser;

namespace PicEditor.Filtros.Constructores
{
    class FilterPipeBuilder : FilterBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            IPipe nextPipe = ObtenerNextPipe(tag.Atributos, hashFiltros);
            FilterPipe f = new FilterPipe(ObtenerNombreFiltro(tag.Atributos), nextPipe);
            return f;
        }
        private IPipe ObtenerNextPipe(ArrayList atributos, Hashtable hashPipes)
        {
            IPipe nextPipe = null;
            string nextPipeName = "";
            foreach (Atributo a in atributos)
            {
                if (a.Nombre == "pipe")
                {
                    nextPipeName = a.Valor;
                }
            }
            if (hashPipes.Contains(nextPipeName))
            {
                nextPipe = (IPipe)hashPipes[nextPipeName];
            }
            return nextPipe;
        }
    }
}
