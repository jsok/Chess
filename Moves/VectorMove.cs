using System;
using System.Collections.Generic;
using System.Text;

using Chess.Pieces;

namespace Chess.Moves
{
    public class VectorMove : IMove
    {
        int x;
        int y;

        public VectorMove(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public List<Position> applyMove(Board board, IPiece piece)
        {
            Position p = piece.Position;
            Position possible;

            List<Position> moves = new List<Position>();

            int scalar;
            for (scalar = 1; scalar < Chess.Board.BOARD_DIMENSION; scalar++)
            {
                possible = new Position(p.Column + scalar * x, p.Row + scalar * y);
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

                if (placementWillTerminateVector(placement))
                    break;
            }

            return moves;
        }

        Boolean placementWillTerminateVector(Position.Placement placement)
        {
            switch (placement)
            {
                case Position.Placement.VALID:
                    return false;

                case Position.Placement.CAPTURE:
                case Position.Placement.BLOCKED:
                case Position.Placement.ILLEGAL:
                default:
                    return true;
            }
        }
    }
}
