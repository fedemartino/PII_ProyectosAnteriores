using System;
using System.Collections.Generic;
using System.Text;
using Drawing;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfaz IAction. Se encarga de transformar 
    /// los dibujos a partir de alguna transformación
    /// </summary>
    public class Transformar : IAction
    {

        private ITransformacion transformacion;
        private Dibujo dibujo;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="transformacion">Transformación que se la aplicará al dibujo</param>
        /// <param name="dibujo">Dibujo al cual se le realizará la transformación</param>
        public Transformar(ITransformacion transformacion, Dibujo dibujo)
        {
            this.dibujo = dibujo;
            this.transformacion = transformacion;
            invariantes();
        }

        /// <summary>
        /// Método que ejecuta la acción de transformar
        /// </summary>
        public void Perform()
        {
            try
            {
                invariantes();
                foreach (Poligono poligono in dibujo.Componentes)
                    poligono.Transformar(transformacion);
                invariantes();
            }
            catch { }
        }

        private void invariantes()
        {
            Debug.Assert(dibujo != null, "El dibujo a pintar no puede ser vacío.");
            Debug.Assert(transformacion != null, "La transformación a realizar no puede ser vacía.");
        }
    }
}
