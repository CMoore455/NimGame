using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nim.Models;

namespace Nim.Models
{
    public class Game
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int CurrentRow { get; set; }
        public int MyProperty { get; set; }
        public Player[] Players { get; set; }
        public Board gameBoard { get; set; }
        public int CurrentPlayerGoingIndex { get; set; }

        public void ComputerMove()
        {
            Random rand = new Random();
            int pieces = 0;
            int row = rand.Next(Rows);
            for(int i = 0; i < Columns; i++)
            {
                if(gameBoard.BoardState[row][i]==1)
                {
                    pieces++;
                }
            }
            int piecesToTakeAway = rand.Next(pieces);
            for (int i = 0; i < pieces; i++)
            {
                if (gameBoard.BoardState[row][i]== 0 && i != Columns - 1)
                {
                    gameBoard.TakeAwayPiece(row, i++);
                }
                else
                {
                gameBoard.TakeAwayPiece(row, i);
                }
            }
        }
    }
}
