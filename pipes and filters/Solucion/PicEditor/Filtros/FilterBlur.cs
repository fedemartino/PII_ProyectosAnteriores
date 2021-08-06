using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Drawing;

namespace PicEditor.Filtros
{
    class FilterBlur : FilterComplex, IFilter
    {
        public FilterBlur() : this ("blur")
        {}
        /// <summary>
        /// Recibe el nombre con el cual se va a crear el objeto e inicializa las variables con los 
        /// valores adecuados para genrerar un filtro de suavizado
        /// </summary>
        /// <param name="name">Nombre del filtro</param>
        public FilterBlur(string name)
        {
            this.name = name;
            matrizParametros = new int[3, 3];
            complemento = 0;
            divisor = 9;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    matrizParametros[x, y] = 1;
                }
            }
        }
    }
}
