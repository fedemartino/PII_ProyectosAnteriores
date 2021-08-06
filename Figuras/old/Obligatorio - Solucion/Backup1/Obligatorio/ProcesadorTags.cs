using System;
using System.Collections;
using System.Text;
using Drawing;
using System.Drawing;
using System.Collections.Generic;

namespace Obligatorio
{
    /// <summary>
    /// Clase encargada de analizar un poligono. 
    /// </summary>
    public class ProcesadorTags
    {
        private IList<Tags> tags;
        private Executor ejecutor;
        private BoardPainter board;
        private IList<Dibujo> dibujos = new List<Dibujo>();

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="tags">Lista que contiene los tags a procesar</param>
        /// <param name="ejecutor">Objeto ejecutor que inicia las acciones</param>
        /// <param name="board">Objeto que va a pintar las figuras</param>
        public ProcesadorTags(IList<Tags> tags, Executor ejecutor, BoardPainter board)
        {
            this.tags = tags;
            this.ejecutor = ejecutor;
            this.board = board;
        }

        /// <summary>
        /// Se encarga de identificar el tipo de determinado poligno. 
        /// </summary>
        /// <param name="res">Lista con los poligonos y sus atributos.</param>
        public Executor IdentificarProceso()
        {
            foreach (Tags tag in tags)
                switch (tag.Nombre)
                {
                    case "square": procesarCuadrado(tag);
                        break;
                    case "rectangle": procesarRectangulo(tag);
                        break;
                    case "triangle": procesarTriangulo(tag);                        
                        break;
                    case "drawing": procesarDrawing(tag);
                        break;
                    case "paint": procesarPaint(tag);
                        break;
                    case "pause": procesarPause(tag);
                        break;
                    case "simetry-x": procesarSimetriaX(tag);
                        break;
                    case "simetry-y": procesarSimetriaY(tag);
                        break;
                    case "simetry": procesarSimetriaCentral(tag);
                        break;
                    case "rotation": procesarRotacion(tag);
                        break;
                    case "translation": procesarTraslacion(tag);
                        break;
                    default:
                        break;
                }
            return ejecutor;
        }

        /// <summary>
        /// Método que se encarga de crear el Cuadrado a partir de los datos contenidos en el tag
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        /// <returns>Cuadrado creado</returns>
        private Poligono armarCuadrado(Tags tag)
        {
            int ladoCuadrado = Convert.ToInt32((tag.Atributos)["length"]);
            Poligono square = new Cuadrado(ladoCuadrado);
            square.CalcularVertices(tag);
            return square;
        }

        /// <summary>
        /// Método que se encarga de crear el Rectangulo a partir de los datos contenidos en el tag
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        /// <returns>Rectangulo creado</returns>
        private Poligono armarRectangulo(Tags tag)
        {
            int baseR = Convert.ToInt32((tag.Atributos)["breadth"]);
            int altura = Convert.ToInt32((tag.Atributos)["width"]);
            Poligono rectangulo = new Rectangulo(baseR, altura);
            rectangulo.CalcularVertices(tag);
            return rectangulo;
        }

        /// <summary>
        /// Método que se encarga de crear el Triangulo a partir de los datos contenidos en el tag
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        /// <returns>Triangulo creado</returns>
        private Poligono armarTriangulo(Tags tag)
        {
            int baseT = Convert.ToInt32((tag.Atributos)["base"]);
            int altura = Convert.ToInt32((tag.Atributos)["height"]);
            Poligono triangulo = new Triangulo(baseT, altura);
            triangulo.CalcularVertices(tag);
            return triangulo;
        }

        /// <summary>
        /// Método que agrega los componentes al dibujo
        /// </summary>
        /// <param name="componentesJuntos">String original que contiene los id de los componentes</param>
        /// <param name="miDibujo">Dibujo al cual pertenecen los componentes</param>
        /// <returns>Dibujo con los componentes almacenados</returns>
        private Dibujo armarDibujo(String componentesJuntos, Dibujo miDibujo)
        {
            Dibujo dibujoBuscado;
            Parser miParser = new Parser();
            String[] listaDeComponentes = miParser.ParsearAtributos(componentesJuntos);
            foreach (String componente in listaDeComponentes)
            {
                dibujoBuscado = buscarDibujo(componente);
                if (dibujoBuscado != null && (dibujoBuscado.Id).Equals(componente))
                {
                    foreach (Poligono poligono in dibujoBuscado.Componentes)
                         miDibujo.AgregarComponente(poligono);                    
                }
            }
            return miDibujo;
         }
            
       /// <summary>
       /// Método que busca si la figura se encuentra en el array de dibujos
       /// </summary>
       /// <param name="nombreFigura">Id de la figura a buscar</param>
       /// <returns>Dibujo al cual pertenece la figura</returns> 
        private Dibujo buscarDibujo(String nombreFigura)
        {
            foreach (Dibujo miDibu in dibujos)
                if (nombreFigura.Equals(miDibu.Id))
                    return miDibu;
            return null;
        }

        /// <summary>
        /// Método que agrega la simetría axial de eje Y a las acciones a ejecutar
        /// </summary>
        /// <param name="ejeY">Coordenada del eje de simetría</param>
        /// <param name="miDibujo">Dibujo al cual se la realizará la transformación</param>
        private void agregarSimetriaY(Int32 ejeY, Dibujo miDibujo)
        {
            ITransformacion miTransformacion = new SimetriaEjeY(ejeY);
            IAction simetriaY = new Transformar(miTransformacion,miDibujo);
            ejecutor.AddAction(simetriaY);
        }

        /// <summary>
        /// Método que agrega la simetría axial de eje X a las acciones a ejecutar
        /// </summary>
        /// <param name="ejeY">Coordenada del eje de simetría</param>
        /// <param name="miDibujo">Dibujo al cual se la realizará la transformación</param>
        private void agregarSimetriaX(Int32 ejeX, Dibujo miDibujo)
        {
            ITransformacion miTransformacion = new SimetriaEjeX(ejeX);
            IAction simX = new Transformar(miTransformacion, miDibujo);
            ejecutor.AddAction(simX);
        }

        /// <summary>
        /// Método que se encarga de procesar los datos para crear el cuadrado
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarCuadrado(Tags tag)
        {
            String idCuadrado = Convert.ToString((tag.Atributos)["id"]);
            Dibujo miCuadrado = new Dibujo(idCuadrado);
            Poligono cuadrado = armarCuadrado(tag);
            if (cuadrado != null)
            {
                miCuadrado.AgregarComponente(cuadrado);
                dibujos.Add(miCuadrado);
            }
        }

        /// <summary>
        /// Método que se encarga de procesar los datos para crear el rectangulo
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarRectangulo(Tags tag)
        {
            String idRectangulo = Convert.ToString((tag.Atributos)["id"]);
            Dibujo miRectangulo = new Dibujo(idRectangulo);
            Poligono rectangulo = armarRectangulo(tag);
            if (rectangulo != null)
            {
                miRectangulo.AgregarComponente(rectangulo);
                dibujos.Add(miRectangulo);
            }
        }

        /// <summary>
        /// Método que se encarga de procesar los datos para crear el triangulo
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarTriangulo(Tags tag)
        {
            String idTriangulo = Convert.ToString((tag.Atributos)["id"]);
            Dibujo miTriangulo = new Dibujo(idTriangulo);
            Poligono triangulo = armarTriangulo(tag);
            if (triangulo != null)
            {
                miTriangulo.AgregarComponente(triangulo);
                dibujos.Add(miTriangulo);
            }
        }

        /// <summary>
        /// Método que se encarga de procesar los datos para crear el dibujo compuesto de dibujos
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarDrawing(Tags tag)
        {
            String idDibujo = Convert.ToString((tag.Atributos)["id"]);
            String componentes = Convert.ToString((tag.Atributos)["components"]);
            Dibujo NuevoDibujo = new Dibujo(idDibujo);
            dibujos.Add(armarDibujo(componentes, NuevoDibujo));
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de pintar
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarPaint(Tags tag)
        {
            String nombreFigura = Convert.ToString((tag.Atributos)["figure"]);
            String nombreColor = Convert.ToString((tag.Atributos)["color"]);
            Color color = Color.FromName(nombreColor);
            Dibujo DibujoAPintar = buscarDibujo(nombreFigura);
            if (DibujoAPintar.Componentes != null)
            {
                IAction pintar = new Pintar(DibujoAPintar, color, board);
                ejecutor.AddAction(pintar);
            }
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de pausar
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarPause(Tags tag)
        {
            Int32 tiempo = Convert.ToInt32((tag.Atributos)["millis"]);
            IAction pausar = new Pausar(tiempo);
            ejecutor.AddAction(pausar);
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de simetrizar respecto a X
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarSimetriaX(Tags tag)
        {
            Int32 ejeX = Convert.ToInt32((tag.Atributos)["coordinate"]);
            String nombreDibujoX = Convert.ToString((tag.Atributos)["figure"]);
            Dibujo DibujoSimX = buscarDibujo(nombreDibujoX);
            agregarSimetriaX(ejeX, DibujoSimX);
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de simetrizar respecto a Y
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarSimetriaY(Tags tag)
        {
            Int32 ejeY = Convert.ToInt32((tag.Atributos)["coordinate"]);
            String nombreDibujoY = Convert.ToString((tag.Atributos)["figure"]);
            Dibujo DibujoSimY = buscarDibujo(nombreDibujoY);
            agregarSimetriaY(ejeY, DibujoSimY);
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de simetrizar
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarSimetriaCentral(Tags tag)
        {
            Int32 ejeXSim = Convert.ToInt32((tag.Atributos)["x"]);
            Int32 ejeYSim = Convert.ToInt32((tag.Atributos)["y"]);
            String nombreDibujoSimetria = Convert.ToString((tag.Atributos)["figure"]);
            Dibujo DibujoSimetria = buscarDibujo(nombreDibujoSimetria);
            agregarSimetriaX(ejeXSim, DibujoSimetria);
            agregarSimetriaY(ejeYSim, DibujoSimetria);
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de rotar
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarRotacion(Tags tag)
        {
            Int32 origenX = Convert.ToInt32((tag.Atributos)["x"]);
            Int32 origenY = Convert.ToInt32((tag.Atributos)["y"]);
            Int32 angulo = Convert.ToInt32((tag.Atributos)["angle"]);
            String nombreDibujoRotacion = Convert.ToString((tag.Atributos)["figure"]);
            Dibujo DibujoRotacion = buscarDibujo(nombreDibujoRotacion);
            ITransformacion rotacion = new Rotacion(origenX, origenY, angulo);
            IAction rotar = new Transformar(rotacion, DibujoRotacion);
            ejecutor.AddAction(rotar);
        }

        /// <summary>
        /// Método que se encarga de procesar la acción de trasladar
        /// </summary>
        /// <param name="tag">Objeto Tags que contiene los datos del tag</param>
        private void procesarTraslacion(Tags tag)
        {
            Int32 traslacionX = Convert.ToInt32((tag.Atributos)["x"]);
            Int32 traslacionY = Convert.ToInt32((tag.Atributos)["y"]);
            String nombreDibujoTraslacion = Convert.ToString((tag.Atributos)["figure"]);
            Dibujo DibujoTraslacion = buscarDibujo(nombreDibujoTraslacion);
            ITransformacion traslacion = new Traslacion(traslacionX, traslacionY);
            IAction trasladar = new Transformar(traslacion, DibujoTraslacion);
            ejecutor.AddAction(trasladar);
        }
    }
}
