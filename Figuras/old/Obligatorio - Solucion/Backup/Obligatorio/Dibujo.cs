using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Drawing;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa los objetos del tipo Dibujo.
    /// Cada dibujo tendrá un identificador y una lista de componentes (figuras)
    /// </summary>
    public class Dibujo
    {
        private String id;
        private IList<Poligono> componentes = new List<Poligono>(); 

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Identifiador del Dibujo</param>
        public Dibujo(String id)
        {
            this.id = id;
            invariantes();
        }

        /// <summary>
        /// Devuelve la lista de componentes (figuras) del Dibujo
        /// </summary>
        public IList<Poligono> Componentes { get { return componentes; } }

        /// <summary>
        /// Devuelve el identificador del Dibujo
        /// </summary>
        public String Id { get { return id; } }


        /// <summary>
        /// Método que agrega una figura al Dibujo
        /// </summary>
        /// <param name="figura">Figura del tipo Poligono que se agregará al Dibujo</param>
        public void AgregarComponente(Poligono figura)
        {
            try
            {
                invariantes();
                Debug.Assert(figura != null, "La figura no puede ser nula."); 
                componentes.Add(figura);
                invariantes();
            }
            catch { }
        }


        private void invariantes()
        {
            Debug.Assert(id != null, "El id del dibujo no puede ser vacío.");
        }
    }
}
