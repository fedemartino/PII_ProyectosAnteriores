using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Collections;
using System.Diagnostics;

namespace PicEditor.Macros
{
    class MacroBuilderListener : IGuiListener, IMacroListener
    {
        private bool recording = false;
        private ISecuencia macro;
        private Stack<IFilter> filterStack;
        private Hashtable filterHash;
        private IPicfilGui gui;

        public MacroBuilderListener(Hashtable filterHash, IPicfilGui gui) 
        {
            this.filterHash = filterHash;
            this.filterStack = new Stack<IFilter>();
            this.gui = gui;
        }

        #region Miembros de IMacroListener
        /// <summary>
        /// Indica el comienzo del a grabacion del macro y genera un objeto del tipo Macro
        /// con el nombre que recibe por parametro.
        /// </summary>
        /// <param name="macroName">Nombre del macro</param>
        public void RecordMacro(string macroName)
        {
            this.macro = new Macro(macroName);
            recording = true;
        }
        /// <summary>
        /// Indica el final de la grabacion del macro y agrega todos los filtros seleccionados al macro.
        /// </summary>
        public void StopRecordMacro()
        {
            Debug.Assert(recording);
            recording = false;
            while (filterStack.Count > 0)
            {
                this.macro.AddStep(filterStack.Pop());
            }
            filterHash.Add(((NamedObject)this.macro).Name, this.macro);
            gui.AddFilter(((NamedObject)this.macro).Name);
        }

        #endregion

        #region Miembros de IGuiListener
        /// <summary>
        /// Genera una pila y agrega los filtros que se vayan seleccionando cuando se esta grabando un macro.
        /// </summary>
        /// <param name="filterName">Nombre del filtro seleccionado</param>
        public void ApplyFilter(string filterName)
        {
            if (recording)
            {
                this.filterStack.Push((IFilter)filterHash[filterName]);                
            }
        }

        public void SelectPicture(string pictureName)
        {            
        }

        #endregion
    }
}
