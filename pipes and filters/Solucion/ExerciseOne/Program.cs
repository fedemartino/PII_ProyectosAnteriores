using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TagParser
{
    class Program
    {
        /// <summary>
        /// Punto de entrada
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Para uniformizar la entrega del obligatorio les pedimos que usen un archivo
            // llamado "archivo.txt" que debe estar en el mismo directorio que el programa.
            // En Visual Studio 2005, pueden agregar un nuevo elemento del tipo archivo de
            // texto y llamarlo "archivo.txt" a su solución; luego cambien la propiedad
            // "CopyToOutputDirectory de ese nuevo elemento a "Copy always": con esto
            // podrán modificar el archivo desde el entorno integrado y asegurarse que al
            // depurar la versión más reciente del archivo se copia al directorio desde donde
            // se ejecuta el programa.

            XmlParser x = new XmlParser();
            
            const String fileName = "archivo.txt";
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            UriBuilder builder = new UriBuilder("file", "", 0, path);
            String uri = builder.Uri.ToString();

            // Creamos un nuevo descargador pasándole una ubicación.
            Downloader downloader = new Downloader(uri);

            // Pedimos al descargador que descargue el contenido
            String content = downloader.Download();
            ArrayList listaTags = x.ParsearTexto(content);
            // Imprimimos el contenido en la consola y esperamos una tecla para terminar
            Console.WriteLine(content);
            Console.WriteLine();
            foreach (Tag t in listaTags)
            {
                Console.WriteLine(t.Imprimir());
            }
            
            Console.ReadKey();
        }
    }
}
