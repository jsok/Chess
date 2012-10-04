using System;
using System.Collections.Generic;
using System.Text;

using Chess.Moves;

namespace Chess.Pieces
{
    public class Knight : IPiece
    {
        public Knight(PieceColour colour, Position p)
        {
            this.colour = colour;
            this.position = p;

            // Knights move in L fashion, enumerate all orientations
            moves = new List<IMove>();
            moves.Add(new FixedMove(1, 2));
            moves.Add(new FixedMove(2, 1));
            moves.Add(new FixedMove(-1, 2));
            moves.Add(new FixedMove(-2, 1));
            moves.Add(new FixedMove(-1, -2));
            moves.Add(new FixedMove(-2, -1));
            moves.Add(new FixedMove(-1, 2));
            moves.Add(new FixedMove(-2, 1));
        }

        List<IMove> moves;
        public List<IMove> Moves
        {
            get { return moves; }
        }

        PieceColour colour;
        public PieceColour Colour
        {
            get { return colour; }
        }

        Position position;
        public Position Position
        {
            get { return position; }
        }

        public String Avatar
        {
            get { return "N"; }
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
