using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PainterLib;

namespace ConsoleApplication1
{
    public class Block : IShapedThing
    {
        IPoint[] points;
        Color color;
        public Block()
        {
            this.points = new IPoint[8]; 
            this.points[0] = new Point(0,0);
            this.points[1] = new Point(0, 10);
            this.points[2] = new Point(10, 10);
            this.points[3] = new Point(10, 0);
            this.points[4] = new Point(0, 10);
            this.points[5] = new Point(0, 0);
            this.points[6] = new Point(10, 10);
            this.points[7] = new Point(10, 0);

            this.color = new Color(255, 255, 255);
        }
        public void ChangePos(IPoint pos)
        {
            IPoint[] newPoints = new IPoint[8];
            int i = 0;
            foreach (IPoint p in points)
            {
                newPoints[i++] = new Point(p.X + pos.X, p.Y + pos.Y);
            }
            this.points = newPoints;
        }
        public IPoint[] Points
        {
            get { return this.points; }
        }

        public Color ShapeColor
        {
            get { return this.color; }
        }
    }
}
