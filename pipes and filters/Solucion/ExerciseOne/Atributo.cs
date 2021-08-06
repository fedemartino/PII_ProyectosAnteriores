using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TagParser
{
    public class Atributo
    {
        private readonly string nombre;
        private string valor;
        public Atributo(string nombre, string valor)
        {
            this.nombre = nombre;
            this.valor = valor;
        }
        /// <summary>
        /// Devuelve el nombre del atributo
        /// </summary>
        public String Nombre
        {
            get { return this.nombre; }
        }
        /// <summary>
        /// setea o devuelve el valorn del atributo
        /// </summary>
        public String Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }
        /// <summary>
        /// Devuelve un string con el nombre del atributo y su valor
        /// </summary>
        /// <returns>String con el nombre y valor del atributo</returns>
        public string Imprimir()
        {
            return nombre + "=" + valor;
        }
    }
}
