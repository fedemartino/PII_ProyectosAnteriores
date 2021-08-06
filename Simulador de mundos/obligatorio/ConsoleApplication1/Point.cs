using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Point : PainterLib.IPoint
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        int PainterLib.IPoint.X
        {
            get { return this.x; }
        }

        int PainterLib.IPoint.Y
        {
            get { return this.y; }
        }
    }
}
