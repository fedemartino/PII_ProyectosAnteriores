using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Lib
{
    /// <summary>
    /// Un color.
    /// </summary>
    /// <remarks>
    /// Esta clase permite representar hasta 16 millones de colores, en baes 
    /// a sus componentes rojo (R), verde (G) y azul (B). La intensidad de
    /// cada componente puede variar de 0 (sin color) hasta 255.
    /// Por ejemplo, un color creado a partir de R=255, G=255 y B=0 generara
    /// un color amarillo, mientras que R=0, G=0 y B=255 generara uno 
    /// puramente azul.
    /// </remarks>
    public sealed class Color
    {
        private readonly Int32 rgb;

        /// <summary>
        /// Construye un nuevo color a partir del codigo RGB del color. 
        /// </summary>
        /// <remarks>
        /// El codigo incluye cada uno de los componentes, donde el B 
        /// corresponde a los bits 0 al 7, G los bits del 8 al 15, y 
        /// R del 16 al 23
        /// </remarks>
        /// <param name="rgb"></param>
        public Color(Int32 rgb)
        {
            Debug.Assert(rgb >= 0);

            this.rgb = rgb;
        }
        /// <summary>
        /// Construye un color a partir de cada uno de los componentes.
        /// </summary>
        /// <remarks>
        /// Los componentes van de 0 a 255.
        /// </remarks>
        /// <param name="r">componente rojo</param>
        /// <param name="g">componente verde</param>
        /// <param name="b">componente azul</param>
        public Color(Int32 r, Int32 g, Int32 b)
            : this(((r & 0xff) << 16) | ((g & 0xff) << 8) | (b & 0xff))
        {
            Debug.Assert(r >= 0);
            Debug.Assert(g >= 0);
            Debug.Assert(b >= 0);
        }

        /// <summary>
        /// Retorna el valor RGB del color.
        /// </summary>
        /// <returns>el valor RGB del color</returns>
        public Int32 ToRgb()
        {
            return rgb;
        }

        /// <summary>
        /// Retorna el valor ARGB del color.
        /// </summary>
        /// <remarks>
        /// Esta implementacion de color no permite especificar el canal alpha, por
        /// lo cual este metodo siempre retorna 255 en el componente alpha.
        /// </remarks>
        /// <returns>El valor ARGB del color.</returns>
        public Int32 ToArgb()
        {
            return (0xff << 24) | rgb;
        }
    }
}
