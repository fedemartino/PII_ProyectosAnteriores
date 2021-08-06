using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagParser;
using PicfilLib;
using System.Collections;
using PicEditor.Filtros.Pipes;

namespace PicEditor.Filtros.Constructores
{
    class MacroBuilder : PipeBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            IPipe nextPipe = ObtenerNextPipe(tag.Atributos, "FirstStep", hashFiltros);
            Macro m = new Macro(ObtenerNombrePipe(tag.Atributos), nextPipe);
            //hashFiltros.Add(m.Name, m);
            return m;
        }
        protected IPipe ObtenerNextPipe(ArrayList atributos, string nombreAtributo, Hashtable hashPipes)
        {
            IPipe nextPipe = null;
            string nextPipeName = "";
            foreach (Atributo a in atributos)
            {
                if (a.Nombre == nombreAtributo)
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
