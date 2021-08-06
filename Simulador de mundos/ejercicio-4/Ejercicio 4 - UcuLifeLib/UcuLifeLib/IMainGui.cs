using System;
using System.Collections.Generic;
using System.Text;
using PainterLib;

namespace UcuLifeLib
{
    /// <summary>
    /// La interfaz principal de UcuLife
    /// </summary>
    public interface IMainGui: IGui
    {        
        /// <summary>
        /// Agrega un observador para eventos en la interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        void AddGuiListener(IGuiListener listener);

        /// <summary>
        /// Retorna si el observador ya esta registrado.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns>verdadero si ya esta registrado, falso en otro caso</returns>
        Boolean ContainsGuiListener(IGuiListener listener);

        /// <summary>
        /// Agrega un mundo a la interfaz con el nombre especificado.
        /// </summary>
        /// <param name="worldName">el nombre del mundo</param>
        void AddWorld(String worldName);

        /// <summary>
        /// Retorna si el mundo ya esta registrado.
        /// </summary>
        /// <param name="worldName">el nombre del mundo</param>
        /// <returns>verdadero si ya esta registrado, falso en otro caso</returns>
        Boolean ContainsWorld(String worldName);

        /// <summary>
        /// Agrega una cosa a la interfaz con el nombre especificado.
        /// </summary>
        /// <param name="worldName">la cosa</param>
        void AddThing(String id);

        /// <summary>
        /// Retorna si la cosa ya esta registrada.
        /// </summary>
        /// <param name="worldName">el nombre de la cosa</param>
        /// <returns>verdadero si ya esta registrada, falso en otro caso</returns>        
        Boolean ContainsThing(String id);

        /// <summary>
        /// Ejecuta la interfaz.
        /// </summary>
        void Run();
    }
}
