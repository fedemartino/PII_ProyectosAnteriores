using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicEditor.Filtros;
using PicfilLib;
using System.Diagnostics;
using System.Collections;

namespace PicEditor
{
    class HashListener : PicfilLib.IGuiListener, IPicturePersistListener
    {
        private IPicture picture;
        private IPictureRenderer renderer;
        private Hashtable hashFiltros;
        private bool selectedPicture;
        /// <summary>
        /// Escucha los mensajes del GUI
        /// </summary>
        /// <param name="formBoard">Form en el cual mostrar los resultados</param>
        /// <param name="hashFiltros">hashTable con todos los filtros</param>
        public HashListener(FormBoard formBoard, Hashtable hashFiltros)
        {
            this.selectedPicture = false;
            this.picture = new Picture(1,1);
            this.hashFiltros = hashFiltros;
            this.renderer = new PictureFormRenderer(formBoard);
        }
        /// <summary>
        /// Aplica el filtro seleccionado y lo muestra en pantalla
        /// </summary>
        /// <param name="filterName">Nombre del filtro que se debe aplicar</param>
        public void ApplyFilter(string filterName)
        {
            Debug.Assert(hashFiltros[filterName] != null,"El filtro seleccionado no existe");
            Debug.Assert(selectedPicture, "No hay una imagen seleccionada");
            IFilter f = (IFilter)hashFiltros[filterName];
            picture = f.Filter(picture);
            renderer.Render(picture);
        }
        public void SelectPicture(string pictureName)
        {
            IPictureProvider p = new PictureProvider();
            p.ReadIntoImage(pictureName, picture);
            selectedPicture = true;
            renderer.Render(picture);
        }
        #region Miembros de IPicturePersistListener

        /// <summary>
        /// Graba en disco la imagen a la cual se le aplicaron los filtros.
        /// </summary>
        /// <param name="fileName">Path donde se quiere grabar la imagen</param>
        public void PersistPicture(string fileName)
        {
            PictureToFilePersister persistidor = new PictureToFilePersister();
            persistidor.Persist(this.picture, fileName);
        }

        #endregion
    }
}
