using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        
        public ObservableCollection<ObservableCollection<Piece>> BoardState { get; set; }

        public void TakeAwayPiece()
        {
            TotalPieces--;
        }
    }

}
