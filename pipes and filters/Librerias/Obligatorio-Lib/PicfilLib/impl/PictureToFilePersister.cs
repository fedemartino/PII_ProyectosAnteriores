using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace PicfilLib
{
    /// <summary>
    /// Un persistidor de imagenes a archivos.
    /// </summary>
    /// <remarks>
    /// Se encarga de persistir una imagen a un archivo pasado por parametro.
    /// </remarks>
    public class PictureToFilePersister: IPicturePersister
    {
        private readonly PictureTransformer transformer = new PictureTransformer();

        #region IPicturePersister Members

        /// <summary>
        /// Persiste la imagen.
        /// </summary>
        /// <param name="picture">la imagen, distinto de nulo</param>
        /// <param name="fileName">el nombre del archivo, distinto de nulo</param>
        public void Persist(IPicture picture, string fileName)
        {
            Debug.Assert(picture != null);
            Debug.Assert(fileName != null);

            Bitmap bitmap = transformer.GetBitmap(picture);
            bitmap.Save(fileName);
        }

        #endregion
    }
}
