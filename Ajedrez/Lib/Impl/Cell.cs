using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Impl
{
    class Cell : ICell
    {
        Color color;
        IShapedPiece piece;

        public IShapedPiece GetPiece()
        {
            return this.piece;
        }

        public Cell(Color color)
        {
            this.color = color;
        }
        public void AddPiece(IShapedPiece piece)
        {
            this.piece = piece;
        }

        public void RemovePiece()
        {
            this.piece = null;
        }

        public Color GetColor()
        {
            return this.color;
        }

        public bool HasPiece()
        {
            return this.piece != null;
        }
    }
}
