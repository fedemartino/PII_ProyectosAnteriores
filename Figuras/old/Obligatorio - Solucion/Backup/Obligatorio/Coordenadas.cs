using System;
using System.Collections.Generic;
using System.Text;
using Drawing;

namespace Obligatorio
{   

    /// <summary>
    /// Clase que implementa la interfaz IPoint. Se encarga de
    /// retornar las coordenadas de un punto en el plano.
    /// </summary>
    public class Coordenadas : IPoint
    {

        private int x;
        private int y;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="x">Coordenada del punto en el eje de las x.</param>
        /// <param name="y">Coordenada del punto en el eje de las y.</param>
        public Coordenadas(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        #region IPoint Members

        /// <summary>
        /// Devuelve la coordenada X del punto.
        /// </summary>
        public int X { get { return x; }   }
        
        /// <summary>
        /// Devuelve la coordenada Y del punto.
        /// </summary>
        public int Y { get { return y; }  }

        #endregion

    }
}
