using System;
using System.Collections.Generic;
using System.Text;

using Chess.Pieces;

namespace Chess.Moves
{
    public interface IMove
    {
        List<Position> applyMove(Board board, IPiece piece);
    }
}
