using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PainterLib;

namespace ConsoleApplication1
{
    interface IShapedThing : IShape, IThing
    {
        Color ShapeColor { get; }
    }
}
