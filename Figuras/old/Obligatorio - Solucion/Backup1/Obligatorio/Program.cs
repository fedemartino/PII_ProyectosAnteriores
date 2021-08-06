using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Drawing;
using System.Collections.Generic;

namespace Obligatorio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const String fileName = "archivo.txt";
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            UriBuilder builder = new UriBuilder("file", "", 0, path);//file es xa archivos locales,http xa bajar de internet
            String uri = builder.Uri.ToString();

            //Creamos un nuevo descargador pasándole una ubicación
            Downloader downloader = new Downloader(uri);

            //Pedimos al descargador que descargue el contenido
            String content = downloader.Download();

            IList<String> tagList = new List<String>();

            ExtraerTags desdeTexto = new ExtraerTags();
            
            //Extraer Tags desde el archivo de entrada y almacenarlos en una lista de strings
            tagList = desdeTexto.DelimiTag(content, tagList);

            Parser parsearTag = new Parser();

            //Se extrae el contenido de cada tag y se almacena en una lista
            IList<Tags> res = parsearTag.TagParser(tagList);

            BoardModel b = new BoardModel(100, 100);
            BoardPainter board = new BoardPainter(b);
            FormBoard f = new FormBoard(b);
            Executor ejecutor = new Executor(f);

            ProcesadorTags tipo = new ProcesadorTags(res, ejecutor, board);
            
            //Se identifica el proceso (crear poligono o una acción) y al finalizar se cargan las acciones en el ejecutor
            ejecutor = tipo.IdentificarProceso();
            ejecutor.Execute();
        }
    }
}