using System;
using System.Collections.Generic;
using System.Text;

using Chess.Pieces;

namespace Chess
{
    /// <summary>
    /// The Chess Board state.
    /// A board is described as a two dimensional array of pieces.
    /// </summary>
    public class Board
    {
        public const int BOARD_DIMENSION = 8;
        IPiece[,] board;

        public Board()
        {
            board = new IPiece[BOARD_DIMENSION, BOARD_DIMENSION];
        }

        /// <summary>
        /// Place a piece on the board. Only a VALID placement is acceptable.
        /// </summary>
        /// <param name="piece">Piece to be placed</param>
        /// <returns>True if placement was successful</returns>
        public Boolean placeOnBoard(IPiece piece)
        {
            if (validPosition(piece, piece.Position) != Position.Placement.VALID)
            {
                return false;
            }

            board[piece.Position.Column, piece.Position.Row] = piece;

            return true;
        }

        public IPiece getPieceAtPosition(Position p)
        {
            return board[p.Column, p.Row];
        }

        Boolean isPieceAtPosition(Position p)
        {
            return (getPieceAtPosition(p) != null);
        }

        Boolean isPositionOnBoard(Position position)
        {
            if (position.Column < 0 || position.Column >= BOARD_DIMENSION)
                return false;
            if (position.Row < 0 || position.Row >= BOARD_DIMENSION)
                return false;

            return true;
        }

        public Position.Placement validPosition(IPiece piece, Position position)
        {
            if (!isPositionOnBoard(position))
                return Position.Placement.ILLEGAL;

            if (isPieceAtPosition(position))
            {
                IPiece occupier = getPieceAtPosition(position);
                if (occupier.Colour == piece.Colour)
                    return Position.Placement.BLOCKED;
                else
                    return Position.Placement.CAPTURE;
            }

            return Position.Placement.VALID;
        }

    }

}
