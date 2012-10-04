using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    /// <summary>
    /// The Position class is responsible for describing a column and row
    /// position on a Chess Board.
    /// 
    /// Only minimal work is done to ensure the position is sane.
    /// Position validation is delegated to the Board.
    /// </summary>
    public class Position
    {
        public enum Placement
        {
            VALID = 0,
            CAPTURE,
            BLOCKED,
            ILLEGAL,
        }

        int row;
        public int Row
        {
            get { return row; }
        }

        int col;
        public int Column
        {
            get { return col; }
        }

        // Constructor which takes human readable positions
        public Position(char col, int row)
        {
            this.col = columnIndex(col);
            // Board starts at 1, not 0
            this.row = row - 1;
        }

        // Constructor for 0-based board co-ordinates
        public Position(int col, int row)
        {
            this.col = col;
            this.row = row;
        }

        int columnIndex(char col)
        {
            return (col - 'a');
        }

        public static Boolean tryParse(String input, out Position result)
        {
            char col;
            int row;

            if ((input.Length >= 2) &&
                (input[0] >= 'a' && input[0] <= 'h') &&
                (Int32.TryParse(input.Substring(1, 1), out row)))
            {
                col = input[0];
                result = new Position(col, row);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override string ToString()
        {
            Char column = (Char)('a' + this.col);
            // Return human readable board position
            return String.Format("{0}{1}", column, this.row + 1);
        }
    }
}
