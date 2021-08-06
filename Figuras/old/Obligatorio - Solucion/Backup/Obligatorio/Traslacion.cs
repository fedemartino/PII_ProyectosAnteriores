using System;
using System.Collections;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Clase encargada de realizar la traslaci�n.
    /// </summary>
    public class Traslacion : ITransformacion
    {
        private Int32 traslacionX;
        private Int32 traslacionY;
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="traslacionX">Cantidad de unidades que se va a trasladar un punto en el eje X.</param>
        /// <param name="traslacionY">Cantidad de unidades que se va a trasladar un punto en el eje Y.</param>
        public Traslacion(Int32 traslacionX,Int32 traslacionY)
        {
            this.traslacionX = traslacionX;
            this.traslacionY = traslacionY;
        }

        /// <summary>
        /// M�todo encargado de realizar la traslaci�n de los puntos que se le son pasados por 
        /// par�metro.
        /// </summary>
        /// <param name="puntos">Lista de puntos a ser trasladados.</param>
        /// <returns>Lista con los nuevos puntos, luego de haberles aplicado la traslaci�n.</returns>
        public IPoint[] HacerTransformacion(IPoint[] puntos)
        {
            IPoint[] puntosTrasladados = new Coordenadas[puntos.Length];

            for (int i = 0; i < puntos.Length; i++)
            {
                puntosTrasladados[i] = new Coordenadas(traslacionX + puntos[i].X, traslacionY + puntos[i].Y);
            }
            return puntosTrasladados;
        }
    }
}
