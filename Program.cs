using System;
using System.Collections.Generic;
using System.Text;

using Chess.Pieces;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean continuePlaying = true;

            while (continuePlaying)
            {
                List<IPiece> pieces = readPieces();
                Board board = new Board();

                foreach (IPiece piece in pieces)
                {
                    board.placeOnBoard(piece);
                }

                Console.WriteLine("Valid moves");
                foreach (IPiece piece in pieces)
                {
                    List<Position> moves = piece.findValidMoves(board);
                    moves.Sort();

                    List<String> movesOutput = new List<string>();
                    moves.ForEach(p => movesOutput.Add(p.ToString()));

                    Console.WriteLine(String.Format("{0} on {1}: [{2}]",
                        piece.Avatar,
                        piece.Position,
                        String.Join(", ", movesOutput.ToArray())));
                }

                Console.Write("Continue (Y/N)?: ");
                String input = Console.ReadLine();

                continuePlaying = input.StartsWith("Y");
            }
        }

        static List<IPiece> readPieces()
        {
            String input;
            List<IPiece> pieces = new List<IPiece>();

            int numberPieces = -1;
            while (numberPieces < 0)
            {
                Console.Write("Enter number of pieces: ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out numberPieces))
                    numberPieces = -1;
            }

            int i;
            for (i = 1; i <= numberPieces; i++)
            {
                IPiece piece;

                Console.WriteLine("Piece {0}", i);

                input = "";
                while ((!input.StartsWith("W")) && (!input.StartsWith("B")))
                {
                    Console.Write("Enter colour (W/B): ");
                    input = Console.ReadLine();
                }

                PieceColour colour;
                if (input == "B")
                    colour = PieceColour.BLACK;
                else
                    colour = PieceColour.WHITE;

                input = "";
                while ((!input.StartsWith("B")) && (!input.StartsWith("N")))
                {
                    Console.Write("Enter type (B/N): ");
                    input = Console.ReadLine();
                }
                String pieceType = input;

                input = "";
                Position p;
                while (!Position.tryParse(input, out p))
                {
                    Console.Write("Enter position: ");
                    input = Console.ReadLine();
                }

                if (pieceType.StartsWith("N"))
                    piece = new Knight(colour, p);
                else
                    piece = new Bishop(colour, p);

                pieces.Add(piece);
            }

            return pieces;
        }
    }
}
