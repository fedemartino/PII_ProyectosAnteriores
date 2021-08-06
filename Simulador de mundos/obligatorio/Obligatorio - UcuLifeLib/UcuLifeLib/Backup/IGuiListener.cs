using System;
using System.Collections.Generic;
using System.Text;
using PainterLib;
using UcuLifeLib.Listener;

namespace UcuLifeLib
{

    /// <summary>
    /// Un observador de eventos en la interfaz de UcuLife.
    /// </summary>
    /// <remarks>
    /// Esta interfaz se provee para brindar compatibilidad con versiones
    /// anteriores de la biblioteca de clases. Es posible ahora implementar
    /// un observador para un tipo de evento particular.
    /// </remarks>
    public interface IGuiListener: IWorldSelectedListener, 
        IThingSelectedListener, ICellSelectedListener
    {                        
        
    }
}
