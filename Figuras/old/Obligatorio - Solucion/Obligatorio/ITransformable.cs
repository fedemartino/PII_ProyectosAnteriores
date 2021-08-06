using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio
{
    /// <summary>
    /// Interfaz que implementan todas las figuras que se van a transformar
    /// No se especifica la transformación
    /// </summary>
    public interface ITransformable
    {
        void Transformar(ITransformacion transformacion);
    }
}
