using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Impl
{
    class CellSelectListener : ICellSelectListener
    {
        IBoard board;
        IGui gui;
        IShapedPiece selectedPiece;
        Coordenada selectedCell;
        public CellSelectListener(IBoard board, IGui gui)
        {
            this.board = board;
            this.gui = gui;
            this.selectedPiece = null;
        }
        public void Listen(Coordenada selectedCell)
        {
            if (this.selectedPiece == null)
            {
                this.selectedPiece = this.board.GetCell(selectedCell.X, selectedCell.Y).GetPiece();
                this.selectedCell = selectedCell;
            }
            else
            {
                this.board.GetCell(this.selectedCell.X, this.selectedCell.Y).RemovePiece();
                this.board.GetCell(selectedCell.X, selectedCell.Y).AddPiece(this.selectedPiece);
                this.selectedPiece = null;
                this.gui.Draw();
            }
        }
    }
}
