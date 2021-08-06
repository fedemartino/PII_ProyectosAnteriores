using System;
using System.Collections.Generic;
using System.Text;
using Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfase de tipo polígono. Tiene la responsabilidad de calcular
    /// el área y el perímetro de determinado rectángulo. 
    /// </summary>
    public class Rectangulo : Poligono
    {
        private Int32 ancho;
        private Int32 largo;

        /// <summary>
        /// Constructor de la Clase.
        /// </summary>
        /// <param name="baseR">Valor de la base del rectángulo.</param>
        /// <param name="altura">Valor de la altura del rectángulo.</param>
        public Rectangulo(int ancho, int largo)
        {
            this.puntos = new Coordenadas[4];
            this.ancho = ancho;
            this.largo = largo;
        }

       /// <summary>
       /// Devuelve el ancho del rectángulo
       /// </summary>
        public Int32 Ancho { get { return ancho; } }

        /// <summary>
        /// Devuelve el largo del rectángulo
        /// </summary>
        public Int32 Largo { get { return largo; } }


        #region Poligono Members

        /// <summary>
        /// A partir de un punto de origen, calcula el resto de los puntos que conforman
        /// la figura.
        /// </summary>
        /// <param name="puntoInicial">Coordenadas del punto de origen</param>
        public override void CalcularVertices(Tags tag)
        {
            invariantes();

            int x = Convert.ToInt32((tag.Atributos)["X"]);
            int y = Convert.ToInt32((tag.Atributos)["Y"]);

            puntos[0] = new Coordenadas(x, y);
            puntos[1] = new Coordenadas(x + ancho - 1, y);
            puntos[2] = new Coordenadas(x + ancho - 1, y + largo - 1);
            puntos[3] = new Coordenadas(x, y + largo - 1);

            invariantes();


        }

        #endregion
        private void invariantes()
        {
            Debug.Assert(ancho > 0 && largo > 0);
            Debug.Assert(ancho > largo);
        }
    }  
}
