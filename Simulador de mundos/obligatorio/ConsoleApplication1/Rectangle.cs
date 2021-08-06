using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Rectangle : PainterLib.IShape
    {
        PainterLib.IPoint[] points;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="pos">posicion del cuadrante superior derecho</param>
        public Rectangle(int height, int width, PainterLib.IPoint pos)
        {
            this.points = new PainterLib.IPoint[4];
            this.points[0] = pos;
            this.points[1] = new Point(pos.X + width, pos.Y);
            this.points[2] = new Point(pos.X + width, pos.Y + height);
            this.points[3] = new Point(pos.X, pos.Y + height);
        }
        public PainterLib.IPoint[] Points
        {
            get { return this.points; }
        }
    }
}
