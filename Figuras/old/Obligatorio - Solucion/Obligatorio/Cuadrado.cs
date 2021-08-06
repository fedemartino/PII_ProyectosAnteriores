using System;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Drawing;

namespace Obligatorio
{
   
    /// <summary>
    /// Clase que implementa la interfase de tipo polígono. Tiene la responsabilidad de calcular
    /// el área y el perímetro de determinado cuadrado. 
    /// </summary>
    public class Cuadrado : Poligono
    {
        private Int32 lado;

        /// <summary>
        /// Constructor de la Clase.
        /// </summary>
        /// <param name="lado">Valor del lado del cuadrado.</param>
        public Cuadrado(int lado)
        {
            this.puntos = new Coordenadas[4];
            this.lado = lado;
            invariantes();
        }
                        
        /// <summary>
        /// Devuelve el lado del cuadrado
        /// </summary>
        public  Int32 Lado { get { return lado; } }

        /// <summary>
        /// A partir de un punto de origen, calcula el resto de los puntos que conforman
        /// la figura.
        /// </summary>
        /// <param name="puntoInicial">Coordenadas del punto de origen.</param>
        public override void CalcularVertices(Tags m)
        {
            invariantes();
            int x = Convert.ToInt32((m.Atributos)["X"]);
            int y = Convert.ToInt32((m.Atributos)["Y"]);
                      
            puntos[0] = new Coordenadas(x , y);
            puntos[1] = new Coordenadas(x + lado - 1 , y);
            puntos[2] = new Coordenadas(x + lado - 1 , y + lado - 1);
            puntos[3] = new Coordenadas(x , y + lado - 1);
            invariantes();
        }

        private void invariantes()
        {
            Debug.Assert(lado > 0, "El lado del cuadrado debe ser mayor a cero.");
        }
    }
}
