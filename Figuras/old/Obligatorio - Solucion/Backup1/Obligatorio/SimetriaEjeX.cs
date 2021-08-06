using System;
using System.Collections;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Clase encargada de realizar la simetria de eje X.
    /// </summary>
    public class SimetriaEjeX : ITransformacion
    {
        private Int32 posEjeX;
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="posEjeX">Posicion del eje a partir del cual se van a simetrizar los puntos.</param>
        public SimetriaEjeX(Int32 posEjeX)
        {
            this.posEjeX = posEjeX;
        }
        /// <summary>
        /// Método encargado de realizar la simetria de los puntos que se le son pasados por 
        /// parámetro, con respecto a un eje X.
        /// </summary>
        /// <param name="puntos">Lista de puntos a ser simetrizados.</param>
        /// <returns>Lista con los nuevos puntos, luego de haberles aplicado la simetria.</returns>
        public IPoint[] HacerTransformacion(IPoint[] puntos)
        {
            IPoint[] puntosSimetrizados = new Coordenadas[puntos.Length];

            for (int i = 0; i < puntos.Length; i++)
            {
                puntosSimetrizados[i] = new Coordenadas(2 * posEjeX - (puntos[i].X), puntos[i].Y);
            }
            return puntosSimetrizados;
        }
         
    }
}