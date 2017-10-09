using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.Models
{
    public class Board
    {
        private int totalPieces;

        public int TotalPieces
        {
            get { return totalPieces; }
            set { totalPieces = value; }
        }

        private int[][] boardState;

        public int[][] BoardState
        {
            get { return boardState; }
            set { boardState = value; }
        }

        public bool TakeAwayPiece(int row, int col)
        {

            return false;
        }
    }

}
