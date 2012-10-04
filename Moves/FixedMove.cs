using System;
using System.Collections.Generic;
using System.Text;

using Chess.Pieces;

namespace Chess.Moves
{
    public class FixedMove : IMove
    {
        int x;
        int y;

        public FixedMove(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public List<Position> applyMove(Board board, IPiece piece)
        {
            Position p = piece.Position;
            Position possible = new Position(p.Column + x, p.Row + y);

            List<Position> moves = new List<Position>();
            Position.Placement placement = board.validPosition(piece, possible);

            switch (placement)
            {
                case Position.Placement.VALID:
                case Position.Placement.CAPTURE:
                    moves.Add(possible);
                    break;

                case Position.Placement.BLOCKED:
                case Position.Placement.ILLEGAL:
                default:
                    break;
            }

            return moves;
        }
    }
}
