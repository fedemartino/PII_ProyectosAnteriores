using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;

namespace PicEditor.Filtros
{
    class FilterEmboss : FilterComplex, IFilter
    {
        public FilterEmboss() : this ("emboss")
        { }
        /// <summary>
        /// Recibe el nombre con el cual se va a crear el objeto e inicializa las variables con los 
        /// valores adecuados para genrerar un filtro de relieve.
        /// </summary>
        /// <param name="name">Nombre del filtro</param>
        public FilterEmboss(string name)
        {
            this.name = name;
            matrizParametros = new int[3, 3];
            divisor = 1;
            complemento = 127;
            matrizParametros[0, 0] = -1;
            matrizParametros[0, 1] = 0;
            matrizParametros[0, 2] = -1;
            matrizParametros[1, 0] = 0;
            matrizParametros[1, 1] = 4;
            matrizParametros[1, 2] = 0;
            matrizParametros[2, 0] = -1;
            matrizParametros[2, 1] = 0;
            matrizParametros[2, 2] = -1;
        }
    }
}
