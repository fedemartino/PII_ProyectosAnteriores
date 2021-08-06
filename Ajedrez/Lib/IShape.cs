using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;

namespace Lib
{
    public interface IShape
    {
        /// <summary>
        /// Debe devolver un Path que representa la forma de la pieza
        /// El path debe estar contenido dentro del recuadro formado por los siguientes puntos:
        /// (0,0);(0,100);(100,100);(100,0)
        /// </summary>
        /// <returns>GraphicsPath que representa la figura</returns>
        GraphicsPath GetShape();
        /// <summary>
        /// Devuelve el color de de la figura
        /// </summary>
        /// <returns></returns>
        Color GetShapeColor();
    }
}
