using System;
using System.Collections.Generic;
using System.Text;
using PainterLib;
using UcuLifeLib.Listener;

namespace UcuLifeLib
{
    /// <summary>
    /// La interfaz principal de UcuLife
    /// </summary>
    public interface IMainGui: IGui
    {
        /// <summary>
        /// Agrega un observador para eventos de un tipo determinado.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Para hacer uso de esta funcion, se debe remplazar T por el tipo del
        /// observador que se quiere registrar. Por ejemplo:
        /// <code>
        /// IMoveListener listener = new MiMoveListener();
        /// gui.AddListener&lt;IMoveListener&gt;(listener);
        /// </code>
        /// </para>
        /// <para>
        /// Los tipos de observadores a los cuales un IMainGui envia eventos 
        /// pertenecen al namespace UcuLifeLib.Listener. Un observador distinto a
        /// estos no recibira ningun evento.
        /// </para>
        /// </remarks>
        /// <param name="listener">el observador</param>
        void AddListener<T>(T listener) 
            where T : IListener;

        /// <summary>
        /// Retorna si el observador ya esta registrado.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns>verdadero si ya esta registrado, falso en otro caso</returns>
        Boolean ContainsListener<T>(T listener) 
            where T: IListener;

        /// <summary>
        /// Agrega un observador para eventos en la interfaz.
        /// </summary>
        /// <remarks>
        /// Esta operacion se mantiene para compatibilidad con versiones anteriores.
        /// Se recomienda usar la operacion para agregar un observador para un evento
        /// especifico.
        /// Llamar a esta operacion es equivalente a llamar a:        
        /// <code>
        /// gui.AddListener&lt;IThingSelectedListener&gt;(listener);
        /// gui.AddListener&lt;IWorldSelectedListener&gt;(listener);
        /// gui.AddListener&lt;ICellSelectedListener&gt;(listener);
        /// </code>
        /// </remarks>
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
