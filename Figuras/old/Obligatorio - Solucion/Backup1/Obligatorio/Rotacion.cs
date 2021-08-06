using System;
using System.Collections.Generic;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Clase encargada de realizar la rotacion.
    /// </summary>
    public class Rotacion : ITransformacion
    {
        private Int32 origenX;
        private Int32 origenY;
        private Int32 angulo;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="origenX">Coordenada X del punto a partir del cual se va a realizar la rotaci�n.</param>
        /// <param name="origenY">Coordenada Y del punto a partir del cual se va a realizar la rotaci�n.</param>
        /// <param name="angulo">�ngulo de rotaci�n.</param>
        public Rotacion(Int32 origenX, Int32 origenY, Int32 angulo)
        {

            this.origenX = origenX;
            this.origenY = origenY;
            this.angulo = angulo;
        }
        
        /// <summary>
        /// M�todo encargado de realizar la rotacion de los puntos que se le son pasados por 
        /// par�metro, con respecto a un punto de origen y un determinado �ngulo.
        /// </summary>
        /// <param name="puntos">Lista de puntos a ser rotados.</param>
        /// <returns>Lista con los nuevos puntos, luego de haberles aplicado la rotacion.</returns>
        public IPoint[] HacerTransformacion(IPoint[] puntos)
        {
            double RADIAN_RATIO = (Math.PI / 180);
            double angle = angulo * RADIAN_RATIO;
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            IPoint[] puntosRotados = new Coordenadas[puntos.Length];

            for (int i = 0; i < puntos.Length; i++)
            {
                int x = puntos[i].X - origenX;
                int y = puntos[i].Y - origenY;
                int nuevoX = ((int)Math.Round((x * cos - y * sin))) + origenX;
                int nuevoY = ((int)Math.Round((x * sin + y * cos))) + origenY;
                puntosRotados[i] = new Coordenadas(nuevoX, nuevoY);
            }

            return puntosRotados;
        }
    }
}
