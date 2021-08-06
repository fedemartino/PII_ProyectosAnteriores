using System;
using System.Collections;
using System.Text;
using Drawing;
using System.Diagnostics;
using System.Windows.Forms;


namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfaz de tipo polígono. Tiene la responsabilidad de calcular
    /// el área y el perímetro de determinado rectángulo. 
    /// </summary>
    public class Triangulo : Poligono
    {
        private Int32 baseT;
        private Int32 altura;

        /// <summary>
        /// Constructor de la clase Triángulo.
        /// </summary>
        /// <param name="baseT">Medida de la base del Triangulo.</param>
        /// <param name="altura">Medida de la altura del Triangulo.</param>
        public Triangulo(int baseT, int altura)
        {
            this.puntos = new Coordenadas[3];
            this.baseT = baseT;
            this.altura = altura;
            invariantes();
        }
        
        /// <summary>
        /// Devuelve la base del triángulo
        /// </summary>
        public Int32 BaseT { get { return baseT; } }

        /// <summary>
        /// Devuelve la altura del triángulo
        /// </summary>
        public Int32 Altura { get { return altura; } }

        
        #region Poligono Members

        /// <summary>
        /// A partir de un punto de origen, calcula el resto de los puntos que conforman
        /// la figura.
        /// </summary>
        /// <param name="puntoInicial">Coordenadas del punto de origen</param>
        public override void CalcularVertices(Tags m)
        {
            invariantes(); 
            
            int x = Convert.ToInt32((m.Atributos)["X"]);
            int y = Convert.ToInt32((m.Atributos)["Y"]);

            puntos[0] = new Coordenadas(x, y);
            puntos[1] = new Coordenadas(x + baseT - 1, y);
            puntos[2] = new Coordenadas(x + baseT - 1, y + altura - 1);
                    
            invariantes();
        }

        #endregion

        private void invariantes()
        {
            Debug.Assert(baseT > 0 && altura > 0);
            Debug.Assert(baseT < altura, "La base del triángulo debe ser mayor que su altura.");
        }
    }
}
