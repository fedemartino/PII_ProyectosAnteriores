
using System;
using System.IO;
using System.Net;

namespace Obligatorio
{
    /// <summary>
    /// Descarga archivos de una ubicaci�n de la forma "http://server/directory/file" o 
    /// "file:///drive:/directory/file"
    /// </summary>
    public class Downloader
    {
        private String url;
        /// <summary>
        /// La ubicaci�n de la cual descargar
        /// </summary>
        public String Url { get { return url; } set { url = value; } }

        /// <summary>
        /// Crea una nueva instancia asignando la ubicaci�n de la cual descargar
        /// </summary>
        /// <param name="url"></param>
        public Downloader(String url)
        {
            this.url = url;
        }

        /// <summary>
        /// Descarga contenido de la ubicaci�n de la cual descargar
        /// </summary>
        /// <returns>Retorna el contenido descargado</returns>
        public String Download()
        {
            // Creamos una nueva solicitud para el recurso especificado por la URL recibida
            WebRequest request = WebRequest.Create(url);

            // Asignamos las credenciales predeterminadas por si el servidor las pide
            request.Credentials = CredentialCache.DefaultCredentials;

            // Obtenemos la respuesta
            WebResponse response = request.GetResponse();

            // Obtenemos la stream con el contenido retornado por el servidor
            Stream stream = response.GetResponseStream();

            // Abrimos la stream con un lector para accederla m�s f�cilmente
            StreamReader reader = new StreamReader(stream);

            // Leemos el contenido
            string result = reader.ReadToEnd();

            // Limpiamos cerrando lo que abrimos
            reader.Close();
            stream.Close();
            response.Close();

            return result;
        }
    }
}
