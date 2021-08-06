using System;
using System.Collections;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Clase encargada de realizar la simetria de eje Y.
    /// </summary>
    public class SimetriaEjeY : ITransformacion
    {
        private Int32 posEjeY;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="posEjeY">Posicion del eje a partir del cual se van a simetrizar los puntos.</param>
        public SimetriaEjeY(Int32 posEjeY)
        {
            this.posEjeY = posEjeY;
        }

        /// <summary>
        /// Método encargado de realizar la simetria de los puntos que se le son pasados por 
        /// parámetro, con respecto a un eje Y.
        /// </summary>
        /// <param name="puntos">Lista de puntos a ser simetrizados.</param>
        /// <returns>Lista con los nuevos puntos, luego de haberles aplicado la simetria.</returns>
        public IPoint[] HacerTransformacion(IPoint[] puntos)
        {
            IPoint[] puntosSimetrizados = new Coordenadas[puntos.Length];

            for (int i = 0; i < puntos.Length; i++)
            {
                puntosSimetrizados[i] = new Coordenadas(puntos[i].X, (2 * posEjeY) - puntos[i].Y);
            }
            return puntosSimetrizados;
        }
    }
}