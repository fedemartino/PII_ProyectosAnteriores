using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Drawing;
using System.Diagnostics;


namespace PicEditor.Filtros
{
    public class FilterBW : NamedObject, IFilter
    {
        private byte threshold;
        
        public FilterBW() : this("blancoNegro", 100)
        { }
        public FilterBW(string name): this(100)
        {
            this.name = name;
        }
        /// <summary>
        /// Recibe un nombre y threshold para crear el filtro blanco y negro.
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="threshold">Limite entre blanco y negro</param>
        public FilterBW(string name, byte threshold) : base(name)
        {
            this.threshold = threshold;
        }
        public FilterBW(byte threshold) : this("blancoNegro", threshold)
        {
            this.threshold = threshold;
        }

        public byte Threshold
        {
            get { return this.threshold;}
            set { this.threshold = value;}
        }
        /// <summary>
        /// Recibe una IPicture y la retorna con el filtro blanco y negro aplicado
        /// </summary>
        /// <param name="image">Imagen a la cual se le va aplicar el filtro</param>
        /// <returns>La imagen con el filtro aplicado</returns>
        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            IPicture bw = image.Clone();
            for (int x = 0; x < bw.Width; x++)
            {
                for (int y = 0; y < bw.Height; y++)
                {
                    Color colorOriginal = bw.GetColor(x, y);

                    byte rOriginal = colorOriginal.R;
                    byte gOriginal = colorOriginal.G;
                    byte bOriginal = colorOriginal.B;
                    Color colorBW;
                    if ((rOriginal > this.threshold) || (gOriginal > this.threshold) || (bOriginal > this.threshold))
                    {
                        colorBW = Color.White;
                    }
                    else 
                    {
                        colorBW = Color.Black;
                    }
                    
                    bw.SetColor(x, y, colorBW);
                }
            }
            return bw;
        }
    }
}
