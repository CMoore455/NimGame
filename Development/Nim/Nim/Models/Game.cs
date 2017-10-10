using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nim.Models;
using System.Windows;

namespace Nim.Models
{
    public class Game
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int MyProperty { get; set; }
        public Player[] Players { get; set; }
        public Board gameBoard { get; set; } = new Board();
        public int CurrentPlayerGoingIndex { get; set; }
        public bool win = false;

        /// <summary>
        /// This method is used to check to see if a player has won by checking the gameBoard.TotalPieces int.
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            bool won = false;
            if (gameBoard.TotalPieces == 1)
            {
                won = true;
            }
            return won;
        }

        /// <summary>
        /// This method changed the CurrentPlayerGoingIndex to the appropriate number (1 or 0). displays a MessageBox of who is going.
        /// </summary>
        public void ChangeTurn()
        {
            if (CurrentPlayerGoingIndex == 0)
            {
                CurrentPlayerGoingIndex++;
            }
            else
            {
                CurrentPlayerGoingIndex--;
            }
            MessageBox.Show($"{Players[CurrentPlayerGoingIndex].PlayerName} is up");
        }

        /// <summary>
        /// This method is for making a move with the computer
        /// </summary>
        public void ComputerMove()
        {
            Random rand = new Random();
            bool loopUp = true;
            int rowPicked = 0;
            int piecesToTake = 0;

            while (loopUp)
            {
                rowPicked = rand.Next(gameBoard.BoardState.Count);
                if (gameBoard.BoardState[rowPicked].Count != 0)
                {
                    loopUp = false;
                }
            }
            piecesToTake = rand.Next(1, gameBoard.BoardState[rowPicked].Count);

            for (int i = 0; i < piecesToTake; i++)
            {
                gameBoard.BoardState[rowPicked].RemoveAt(gameBoard.BoardState[rowPicked].Count - 1);
                gameBoard.TakeAwayPiece();
                if (CheckWin())
                {
                    win = true;
                    break;
                }
            }
            if(!win)
            {
                ChangeTurn();
            }
            

        }
    }
}