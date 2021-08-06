using System;
using System.Collections;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Clase abstracta que implementa las interfaces IShape e Itransformable.
    /// Esta clase define el tipo de todos los poligonos.
    /// </summary>
    public abstract class Poligono : IShape, ITransformable
    {
        /// <summary>
        /// Método encargado de calcular los puntos de determinada figura, a partir 
        /// de un punto de origen que es extraido de m.
        /// </summary>
        /// <param name="m">Contiene la informacion del poligono</param>
        public abstract void CalcularVertices(Tags m);

        #region IShape Members
        
        protected IPoint[] puntos;
        /// <summary>
        /// Propiedad encargada de devolver la lista de puntos que conforman una
        /// figura.
        /// </summary>
        public IPoint[] Points
        {
            get { return puntos; }
        }

        #endregion

        #region ITransformable Members
        /// <summary>
        /// Método encargado de llamar a la transformacion que se le es pasada por 
        /// parametro y actualizar los puntos de la figura con los puntos transformados.
        /// </summary>
        /// <param name="transformacion">La transformacion que se le va a aplicar a la figura</param>
        public void Transformar(ITransformacion transformacion)
        {
            puntos = transformacion.HacerTransformacion(puntos);
        }        

        #endregion
    }
}
