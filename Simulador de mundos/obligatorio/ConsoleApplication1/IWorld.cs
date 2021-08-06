using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PainterLib;

namespace ConsoleApplication1
{
    public interface IWorld
    {
    /// <summary>
    /// Retorna la cosa contenida en la posicion especificada.
    /// </summary>
    /// <param name="x">la coordenada x</param>
    /// <param name="y">la coordenada y</param>
    /// <returns>la cosa, o <code>null</code> si no hay nada en esa
    /// posicion</returns>
    IThing GetThing(Int32 x, Int32 y);
    /// <summary>
    /// Retorna si el mundo contiene la cosa.
    /// </summary>
    /// <param name="thing">la cosa</param>
    /// <returns><code>true</code> si lo contiene, <code>false</code> en
    /// otro caso.</returns>
    Boolean Contains(IThing thing);
    /// <summary>
    /// Retorna si el mundo contiene la cosa en la posicion especificada.
    /// </summary>
    /// <param name="thing">la cosa</param>
    /// <param name="x">la coordenada x de la posicion</param>
    /// <param name="y">la coordenada y de la posicion</param>
    /// <returns><code>true</code> si lo contiene, <code>false</code> en
    /// otro caso.</returns>
    Boolean Contains(IThing thing, Int32 x, Int32 y);
    /// <summary>
    /// Retorna si el mundo contiene la posicion especificada.
    /// </summary>
    /// <param name="x">la coordenada x</param>
    /// <param name="y">la coordenada y</param>
    /// <returns><code>true</code> si la coordenada esta contenida en el
    /// mundo, <code>false</code> en otro caso.</returns>
    Boolean IsInWorld(Int32 x, Int32 y);
    /// <summary>
    /// Guarda la cosa en la posicion x e y del mundo.
    /// </summary>
    /// <param name="thing">la cosa a guardar</param>
    /// <param name="x">la coordenada x</param>
    /// <param name="y">la coordenada y</param>
    void PutThing(IThing thing, Int32 x, Int32 y);
    /// <summary>
    /// Quita la cosa del mundo.
    /// </summary>
    /// <param name="thing">la cosa</param>
    void RemoveThing(IThing thing);
    /// <summary>
    /// Retorna la posicion de la cosa en el mundo.
    /// </summary>
    /// <param name="thing">la cosa</param>
    /// <returns>la posicion de la cosa en el mundo, o <code>null</code>
    /// si no esta contenida en el</returns>
    IPoint GetPosition(IThing thing);
    }
}
