using System;
using System.Collections.Generic;
using System.Text;
using Drawing;

namespace Obligatorio
{
    /// <summary>
    /// Interfaz que implementan todas las transformaciones
    /// </summary>
    public interface ITransformacion
    {
        IPoint[] HacerTransformacion(IPoint[] Puntos);
    }
}
