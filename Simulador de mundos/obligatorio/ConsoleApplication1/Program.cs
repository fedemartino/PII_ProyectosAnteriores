using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            UcuLifeLib.MainGui main = new UcuLifeLib.MainGui(500, 500);
            Block block = new Block();
            World w = new World(450, 450, new Rectangle(450,450,new Point(0,0)));
            w.PutThing(block, 100, 50);
            PainterLib.IBoard b = new PainterLib.BoardModel(500, 500);
            
            PainterLib.IPainter p = new PainterLib.BoardPainter(b, 1);
            //PainterLib.IGui gui = new PainterLib.FormBoard(300, 300);
            p.PaintInBoard(w, new PainterLib.Color(255, 0, 0));
            p.PaintInBoard(block, block.ShapeColor);
            main.AddThing("block");
            Hashtable things = new Hashtable();
            Hashtable worlds = new Hashtable();
            things.Add("block", block);
            worlds.Add("Mundo 1", w);
            Listener l = new Listener(worlds, things, p, b, main);
            main.AddWorld("Mundo 1");
            //gui.Open();
            //gui.Redraw(b);
            //System.Windows.Forms.Application.Run();
            main.AddGuiListener(l);
            main.Open();
            main.Redraw(b);
            main.Run();
        }
    }
}
