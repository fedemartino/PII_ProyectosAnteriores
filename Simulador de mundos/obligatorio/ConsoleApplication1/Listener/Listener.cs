using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UcuLifeLib;
using System.Collections;
using PainterLib;

namespace ConsoleApplication1
{
    class Listener : IGuiListener 
    {
        private IShapedWorld selectedWorld;
        private IShapedThing selectedThing;
        private Hashtable worldHash;
        private Hashtable thingHash;
        private IPainter painter;
        private IMainGui main;
        private IBoard board;
        public Listener(Hashtable worldHash, Hashtable thingHash, IPainter painter, IBoard board, IMainGui main)
        {
            this.worldHash = worldHash;
            this.thingHash = thingHash;
            this.painter = painter;
            this.board = board;
            this.main = main;
        }
        public void WorldSelected(string worldName)
        {
            this.selectedWorld = (IShapedWorld)this.worldHash[worldName];
        }
        public void ThingSelected(string thingName)
        {
            this.selectedThing = (IShapedThing)this.thingHash[thingName];
        }
        public void CellSelected(PainterLib.IPoint selectedCell)
        {
            try
            {
                if (this.selectedThing != null && this.selectedWorld != null)
                {
                    Block b = new Block();
                    b.ChangePos(selectedCell);
                    this.selectedWorld.PutThing(b, selectedCell.X, selectedCell.Y);
                    this.painter.PaintInBoard(b, this.selectedThing.ShapeColor);
                    this.painter.PaintInBoard(this.selectedWorld, this.selectedThing.ShapeColor);
                    this.main.Redraw(board);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
