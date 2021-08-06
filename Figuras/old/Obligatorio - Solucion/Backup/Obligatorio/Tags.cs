using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Esta clase tiene las responsablidad de conocer los datos de un objeto.
    /// </summary>
    public class Tags
    {
        private String nombre;
        Hashtable atributos;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del Tag</param>
        /// <param name="atributos">Atributos del Tag</param>
        public Tags(String nombre, Hashtable atributos)
        {
            this.nombre = nombre;
            this.atributos = atributos;
            invariantes();
        }
        /// <summary>
        /// Setea y devuelve el nombre del Tag
        /// </summary>
        public String Nombre { get { return nombre; } }

       /// <summary>
       /// Setea y devuelve los atributos del Tag
       /// </summary>
        public Hashtable Atributos { get { return atributos; } }

        private void invariantes()
        {
            Debug.Assert(nombre != null, "El dibujo a pintar no puede ser vacío.");
        }
    }

}
