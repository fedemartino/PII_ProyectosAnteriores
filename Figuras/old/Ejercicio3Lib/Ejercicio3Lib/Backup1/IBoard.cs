using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Drawing
{
    /// <summary>
    /// Una pizarra donde se puede pintar.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Retorna si el punto en la coordenada <code>(x,y)</code> está pintado.
        /// </summary>
        /// <param name="x">La coordenada X</param>
        /// <param name="y">La coordenada Y</param>
        /// <returns><code>true</code> si está pintado, <code>false</code> en caso contrario.</returns>
        Boolean IsPainted(Int32 x, Int32 y);

        /// <summary>
        /// Despinta todos los puntos.
        /// </summary>
        void ClearBoard();

        /// <summary>
        /// Despinta el punto en la coordenada <code>(x,y)</code>. Si el punto no está pintado,
        /// no hace nada.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void ClearPoint(Int32 x, Int32 y);

        /// <summary>
        /// Pinta el punto en la coordenada <code>(x,y)</code>.
        /// </summary>
        /// <remarks>
        /// El punto debe estar contenido dentro de la pizarra.
        /// </remarks>
        /// <param name="x">La coordenada X del punto.</param>
        /// <param name="y">La coordenada Y del punto.</param>
        /// <param name="color">El color del punto.</param> 
        void PaintPoint(Int32 x, Int32 y, Color color);

        /// <summary>
        /// Retorna si el punto en la coordenada <code>(x,y)</code> está contenido
        /// dentro de la pizarra.
        /// </summary>
        /// <remarks>
        /// Este método debe ser usado para determinar si es posible pintar un punto
        /// dado de la pizarra.
        /// </remarks>
        /// <param name="x">La coordenada X del punto.</param>
        /// <param name="y">La coordenada Y del punto.</param>
        /// <returns><code>true</code> si esta contenido, <code>false</code> en caso contrario.</returns>
        Boolean IsInBoard(Int32 x, Int32 y);

        /// <summary>
        /// Retorna el color del punto dado por la coordenada <code>(x,y)</code>.
        /// <para>
        /// El punto debe estar pintado.
        /// </para>
        /// </summary>
        /// <param name="x">La coordenada X</param>
        /// <param name="y">La corrdenada Y</param>
        /// <returns>El color del punto.</returns>
        Color GetColor(Int32 x, Int32 y);
        
        /// <summary>
        /// Retorna el máximo valor que toma la coordenada X en la pizarra.
        /// </summary>
        /// <returns>El máximo valor que toma la coordenada X en la pizarra.</returns>
        Int32 MaxX { get; }
        
        /// <summary>
        /// Retorna el máximo valor que toma la coordenada Y en la pizarra.
        /// </summary>
        /// <returns>El máximo valor que toma la coordenada Y en la pizarra.</returns>
        Int32 MaxY { get; }

        /// <summary>
        /// Retorna si se han pintado nuevos puntos desde la última vez que se llamó a 
        /// éste método.
        /// </summary>
        /// <remarks>
        /// Cuando se modifican los puntos pintados
        /// en la pizarra la propiedad retorna <code>true</code>, y posteriores llamados 
        /// retornar <code>false</code> hasta que la pizarra sea cambiada nuevamente.
        /// </remarks>
        Boolean Changed { get; }
    }
}
