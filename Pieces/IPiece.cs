using System;
using System.Collections.Generic;
using System.Text;

using Chess.Moves;

namespace Chess.Pieces
{
    public enum PieceColour
    {
        BLACK = 0,
        WHITE
    }

    public interface IPiece
    {
        String Avatar { get; }
        PieceColour Colour { get; }
        Position Position { get; }
        List<IMove> Moves { get; }

        /// <summary>
        /// Find all the positions which constitute valid moves for the
        /// piece on the supplied board.
        /// </summary>
        /// <param name="board">The given board state</param>
        /// <returns>A list of positions on the board</returns>
        List<Position> findValidMoves(Board board);

        Boolean isFriendly(IPiece piece);
    }
}
