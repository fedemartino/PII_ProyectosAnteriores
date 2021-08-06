using System;
using System.Collections.Generic;
using System.Text;
using Drawing;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfaz IAction. Se encarga de transformar 
    /// los dibujos a partir de alguna transformaci�n
    /// </summary>
    public class Transformar : IAction
    {

        private ITransformacion transformacion;
        private Dibujo dibujo;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="transformacion">Transformaci�n que se la aplicar� al dibujo</param>
        /// <param name="dibujo">Dibujo al cual se le realizar� la transformaci�n</param>
        public Transformar(ITransformacion transformacion, Dibujo dibujo)
        {
            this.dibujo = dibujo;
            this.transformacion = transformacion;
            invariantes();
        }

        /// <summary>
        /// M�todo que ejecuta la acci�n de transformar
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
            Debug.Assert(dibujo != null, "El dibujo a pintar no puede ser vac�o.");
            Debug.Assert(transformacion != null, "La transformaci�n a realizar no puede ser vac�a.");
        }
    }
}
