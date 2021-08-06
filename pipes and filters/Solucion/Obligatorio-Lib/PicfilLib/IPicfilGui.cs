using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// La capa de interaccion entre el usuario y la aplicacion de filtrado de imagenes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Esta interfaz declara todas las operaciones que un objeto puede realizar sobre
    /// la interfaz de usuario de la aplicacion de filtrado de imagenes.
    /// </para>
    /// <para>
    /// Los eventos recibidos por la interfaz son enviados a todos los observadores registrados
    /// en la misma.
    /// </para>
    /// <para>
    /// La interfaz extiende a <code>IPictureRenderer</code> por lo cual provee las operaciones 
    /// declaradas en ella. En particular, permite dibujar una imagen. En este caso, normalmente
    /// las implementaciones de esta interfaz dibujaran la imagen en una de las ventanas provistas
    /// por la interfaz.
    /// </para>
    /// </remarks>
    public interface IPicfilGui : IPictureRenderer
    {
        /// <summary>
        /// Agrega un nuevo filtro a la interfaz para que pueda ser seleccionado por el usuario.
        /// </summary>
        /// <remarks>
        /// <para>
        /// No puede agregarse dos veces el mismo nombre de filtro a la interfaz.
        /// </para>
        /// <para>
        /// La forma en la cual se despliega el filtro es dependiente de la implementacion.
        /// </para>
        /// </remarks>
        /// <param name="filterName">el nombre del filtro a agregar</param>
        void AddFilter(String filterName);

        /// <summary>
        /// Retorna si ya existe un filtro con ese nombre en la interfaz.        
        /// </summary>
        /// <param name="filterName">el nombre del filtro</param>
        /// <returns><code>true</code>si ya existe <code>false</code> en otro caso.</returns>
        Boolean ContainsFilter(String filterName);

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de aplicacion
        /// de filtros o de seleccion de imagenes.
        /// </summary>
        /// <param name="listener">el observador</param>        
        void AddListener(IGuiListener listener);

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        Boolean ContainsListener(IGuiListener listener);

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de macros.
        /// </summary>
        /// <param name="listener">el observador</param>        
        void AddMacroListener(IMacroListener listener);

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        Boolean ContainsMacroListener(IMacroListener listener);
 
        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de persistencia
        /// de filtros.
        /// </summary>
        /// <param name="listener">el observador</param>        
        void AddFilterPersistListener(IFilterPersistListener listener);

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        Boolean ContainsFilterPersistListener(IFilterPersistListener listener);

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de persistencia
        /// de imagenes.
        /// </summary>
        /// <param name="listener">el observador</param>        
        void AddPicturePersistListener(IPicturePersistListener listener);

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        Boolean ContainsPicturePersistListener(IPicturePersistListener listener);

        /// <summary>
        /// Inicia y ejecuta la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Este metodo debe utilizar en lugar de <code>Application.Run()</code>
        /// </remarks>
        void Run();
    }
}
