using System;
using System.Collections.Generic;
using System.Text;

using Chess.Moves;

namespace Chess.Pieces
{
    public class Bishop : IPiece
    {
        public Bishop(PieceColour colour, Position p)
        {
            this.colour = colour;
            this.position = p;

            // Bishops move in diagonal vectors
            moves = new List<IMove>();
            moves.Add(new VectorMove(1, 1));
            moves.Add(new VectorMove(1, -1));
            moves.Add(new VectorMove(-1, 1));
            moves.Add(new VectorMove(-1, -1));
        }

        List<IMove> moves;
        public List<IMove> Moves
        {
            get { return moves; }
        }

        protected PieceColour colour;
        public PieceColour Colour
        {
            get { return colour; }
        }

        protected Position position;
        public Position Position
        {
            get { return position; }
        }

        public String Avatar
        {
            get { return "B"; }
        }

        public List<Position> findValidMoves(Board board)
        {
            List<Position> validPositions = new List<Position>();

            foreach (IMove move in Moves)
            {
                validPositions.AddRange(move.applyMove(board, this));
            }

            return validPositions;
        }
    }
}
