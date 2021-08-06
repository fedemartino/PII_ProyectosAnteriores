using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NUnit.Framework;


namespace TagParser
{
    public class Tag
    {
        private readonly string nombre;
        private ArrayList atributos;
        /// <summary>
        /// Constructor del Tag
        /// </summary>
        /// <param name="nombre">Nombre del tag a crear</param>
        public Tag(String nombre)
        {
            this.nombre = nombre;
            this.atributos = new ArrayList();
        }
        /// <summary>
        /// Setea o devuelve la lista de atributos del tag
        /// </summary>
        public ArrayList Atributos
        {
            set { this.atributos = value; }
            get { return this.atributos; }
        }
        /// <summary>
        /// Devuelve el nombre del tag
        /// </summary>
        public String Nombre
        {
            get { return this.nombre; }
        }
        /// <summary>
        /// Genera un string con los datos del nodo y sus atributos
        /// </summary>
        /// <returns>String con los datos del nodo y sus atributos</returns>
        public string Imprimir()
        {
            string resultado;
            resultado = nombre;
            foreach (Atributo a in atributos)
            {
                resultado = resultado + "\r\n" + a.Imprimir();
            }
            return resultado;
        }
    }
}
