using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PainterLib
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
        private readonly UInt32 argb;

        public UInt32 R
        {
            get { return (argb >> 16) & 0xff; }
        }
        public UInt32 G
        {
            get { return (argb >> 8) & 0xff; }
        }
        public UInt32 B
        {
            get { return argb & 0xff; }
        }

        /// <summary>
        /// Construye un nuevo color a partir del codigo RGB del color. 
        /// </summary>
        /// <remarks>
        /// El codigo incluye cada uno de los componentes, donde el B 
        /// corresponde a los bits 0 al 7, G los bits del 8 al 15, y 
        /// R del 16 al 23
        /// </remarks>
        /// <param name="rgb"></param>
        public Color(UInt32 rgb)
        {
            Debug.Assert(rgb >= 0);

            this.argb = 0xff000000 | (rgb & 0xffffff);
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
        public Color(UInt32 r, UInt32 g, UInt32 b)
            : this(r, g, b, 255)
        {
            Debug.Assert(r >= 0);
            Debug.Assert(g >= 0);
            Debug.Assert(b >= 0);
        }

        /// <summary>
        /// Construye un color a partir de cada uno de los componentes y su canal alpha.
        /// </summary>
        /// <remarks>
        /// Los componentes van de 0 a 255. El canal alpha va de 0 a 255 y representa
        /// la transparencia del color; con a = 0 el color es totalmente transparente, 
        /// con a = 255 es totalmente opaco.
        /// </remarks>
        /// <param name="r">componente rojo</param>
        /// <param name="g">componente verde</param>
        /// <param name="b">componente azul</param>
        /// <param name="a">canal alfa</param>
        public Color(UInt32 r, UInt32 g, UInt32 b, UInt32 a)            
        {                        
            this.argb = ((a & 0xff) << 24) | ((r & 0xff) << 16) | ((g & 0xff) << 8) | (b & 0xff);
        }

        /// <summary>
        /// Retorna el valor RGB del color.
        /// </summary>
        /// <returns>el valor RGB del color</returns>
        public UInt32 ToRgb()
        {
            return argb & 0xffffff;
        }

        /// <summary>
        /// Retorna el valor ARGB del color.
        /// </summary>
        /// <remarks>
        /// Esta implementacion de color no permite especificar el canal alpha, por
        /// lo cual este metodo siempre retorna 255 en el componente alpha.
        /// </remarks>
        /// <returns>El valor ARGB del color.</returns>
        public UInt32 ToArgb()
        {
            return argb;
        }
    }
}
