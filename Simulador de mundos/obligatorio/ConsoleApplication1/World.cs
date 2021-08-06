using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PainterLib;

namespace ConsoleApplication1
{
    class World : IShapedWorld
    {
        IThing[,] world;
        IShape shape;
        public World(int width, int height, IShape shape)
        {
            this.world = new IThing[width, height];
            this.shape = shape;
        }
        public IThing GetThing(int x, int y)
        {
            return this.world[x, y];
        }

        public bool Contains(IThing thing)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IThing thing, int x, int y)
        {
            IThing t = world[x, y];
            return t == thing;
        }

        public bool IsInWorld(int x, int y)
        {
            return ((x < world.GetLength(0)) && (y < world.GetLength(1)));
        }

        public void PutThing(IThing thing, int x, int y)
        {
            this.world[x,y] = thing;
        }

        public void RemoveThing(IThing thing)
        {
            for (int x = 0; x < world.Length - 1; x++)
            {
                for (int y = 0; y < world.Length - 1; y++)
                {
                    if (world[x, y] == thing)
                    {
                        world[x, y] = null;
                    }
                }
            }
        }

        public PainterLib.IPoint GetPosition(IThing thing)
        {
            for (int x = 0; x < world.Length - 1; x++)
            {
                for (int y = 0; y < world.Length - 1; y++)
                {
                    if (world[x, y] == thing)
                    {
                        return new Point(x, y);
                    }
                }
            }
            return null;
        }

        public IPoint[] Points
        {
            get { return this.shape.Points; }
        }

        public Color ShapeColor
        {
            get { throw new NotImplementedException(); }
        }
    }
}
