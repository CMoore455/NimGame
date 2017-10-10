using Nim.Converters;
using Nim.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game = new Game();
        public bool won = false;
        public MainWindow()
        {
            InitializeComponent();


        }
        /// <summary>
        /// This method makes the game board by populating a 2d observable collection
        /// </summary>
        public void MakeGameBoard()
        {
            ObservableCollection<ObservableCollection<Piece>> pieces = new ObservableCollection<ObservableCollection<Piece>>();
            for (int i = 0; i < game.Rows; i++)
            {
                pieces.Add(new ObservableCollection<Piece>());
                for (int j = 0; j < game.Columns; j++)
                {
                    Piece p = new Piece();
                    pieces[i].Add(p);
                }
            }
            game.gameBoard.BoardState = pieces;

        }

        /// <summary>
        /// This method will fill in the nessasry information for the game when the mode of Easy is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameBoard.TotalPieces = 4;
            won = false;
            game.win = false;
            game.Rows = 2;
            game.Columns = 2;
            MakeGameBoard();
            Row1ListBox.ItemsSource = game.gameBoard.BoardState[0];
            Row2ListBox.ItemsSource = game.gameBoard.BoardState[1];
            Row3ListBox.ItemsSource = null;
            Row4ListBox.ItemsSource = null;
            DifficultyMenu.Visibility = Visibility.Collapsed;
            GameBoardUI.Visibility = Visibility.Visible;
            ControlPanel.Visibility = Visibility.Visible;
            Rules.Visibility = Visibility.Collapsed;


        }

        /// <summary>
        /// This method will fill in the nessasry information for the game when the mode of Medium is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameBoard.TotalPieces = 14;
            won = false;
            game.win = false;

            game.Rows = 3;
            game.Columns = 7;
            MakeGameBoard();


            Row1ListBox.ItemsSource = game.gameBoard.BoardState[0];
            Row2ListBox.ItemsSource = game.gameBoard.BoardState[1];
            Row3ListBox.ItemsSource = game.gameBoard.BoardState[2];
            for (int i = 0; i < 5; i++)
            {
                game.gameBoard.BoardState[0].RemoveAt(game.gameBoard.BoardState[0].Count - 1);
            }
            for (int i = 0; i < 2; i++)
            {
                game.gameBoard.BoardState[1].RemoveAt(game.gameBoard.BoardState[1].Count - 1);
            }
            DifficultyMenu.Visibility = Visibility.Collapsed;
            GameBoardUI.Visibility = Visibility.Visible;
            ControlPanel.Visibility = Visibility.Visible;
            Rules.Visibility = Visibility.Collapsed;


        }

        /// <summary>
        /// This method will fill in the nessasry information for the game when the mode of Hard is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameBoard.TotalPieces = 22;
            won = false;
            game.win = false;
            game.Rows = 4;
            game.Columns = 9;
            MakeGameBoard();
            Row1ListBox.ItemsSource = game.gameBoard.BoardState[0];
            Row2ListBox.ItemsSource = game.gameBoard.BoardState[1];
            Row3ListBox.ItemsSource = game.gameBoard.BoardState[2];
            Row4ListBox.ItemsSource = game.gameBoard.BoardState[3];

            for (int i = 0; i < 7; i++)
            {
                game.gameBoard.BoardState[0].RemoveAt(game.gameBoard.BoardState[0].Count - 1);
            }
            for (int i = 0; i < 6; i++)
            {
                game.gameBoard.BoardState[1].RemoveAt(game.gameBoard.BoardState[1].Count - 1);
            }
            for (int i = 0; i < 1; i++)
            {
                game.gameBoard.BoardState[2].RemoveAt(game.gameBoard.BoardState[2].Count - 1);
            }
            DifficultyMenu.Visibility = Visibility.Collapsed;
            GameBoardUI.Visibility = Visibility.Visible;
            ControlPanel.Visibility = Visibility.Visible;
            Rules.Visibility = Visibility.Collapsed;


        }


        /// <summary>
        /// This method will close the mode menu and open the name menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVCButton_Click(object sender, RoutedEventArgs e)
        {
            game.CurrentPlayerGoingIndex = 0;
            StartMenu.Visibility = Visibility.Collapsed;
            PVCNameMenu.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// This method will make the player(s) and give names to them. Also will open up the difficulty menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void PVCNameEnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerNameBox.Text))
            {
                MessageBox.Show("You Must Enter in A Name");
            }
            else
            {

                game.Players = new Player[2] { new Player(PlayerNameBox.Text, true), new Player("Computer", false) };
                PVCNameMenu.Visibility = Visibility.Collapsed;
                DifficultyMenu.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// This method will close the mode menu and open the name menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVPButton_Click(object sender, RoutedEventArgs e)
        {
            game.CurrentPlayerGoingIndex = 0;
            StartMenu.Visibility = Visibility.Collapsed;
            PVPNameMenu.Visibility = Visibility.Visible;

        }


        /// <summary>
        /// This method will make the player(s) and give names to them. Also will open up the difficulty menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVPNameEnterButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(PlayerOneNameBox.Text) || string.IsNullOrEmpty(PlayerTwoNameBox.Text))
            {
                MessageBox.Show("You Must Enter In A Name");
            }
            else
            {

                game.Players = new Player[2] { new Player(PlayerOneNameBox.Text, true), new Player(PlayerTwoNameBox.Text, true) };
                PVPNameMenu.Visibility = Visibility.Collapsed;
                DifficultyMenu.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// This method will be the human player move. It will remove the amount of pieces from the collection specified.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TakeButton_Click(object sender, RoutedEventArgs e)
        {

            int piecesToTake = 0;
            int rowPicked = 0;
            if (!int.TryParse(WhichRowTextBox.Text, out rowPicked))
            {
                MessageBox.Show("Enter in a valid number");
            }
            else
            {

                if (!int.TryParse(HowManyPiecesTextBox.Text, out piecesToTake))
                {
                    MessageBox.Show("Enter in a valid number");
                }
                else
                {
                    if (rowPicked > game.gameBoard.BoardState.Count)
                    {
                        MessageBox.Show("Hold your horses there scooter");
                    }
                    else
                    {
                        if (game.gameBoard.BoardState[rowPicked - 1].Count == 0 || piecesToTake > game.gameBoard.BoardState[rowPicked - 1].Count)
                        {
                            MessageBox.Show("Hold your horses there scooter");
                        }
                        else
                        {
                            for (int i = 0; i < piecesToTake; i++)
                            {
                                game.gameBoard.BoardState[rowPicked - 1].RemoveAt(game.gameBoard.BoardState[rowPicked - 1].Count - 1);
                                game.gameBoard.TakeAwayPiece();
                                if (game.CheckWin())
                                {
                                    won = true;

                                    WinnerLabel.Content = $"{game.Players[game.CurrentPlayerGoingIndex].PlayerName} has won";
                                    PlayerNameBox.Text = null;
                                    PlayerOneNameBox.Text = null;
                                    PlayerTwoNameBox.Text = null;
                                    break;
                                }
                            }

                            if (won)
                            {
                                GameBoardUI.Visibility = Visibility.Collapsed;
                                PlayAgainMenu.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                game.ChangeTurn();
                                if (!game.Players[1].IsHuman)
                                {
                                    game.ComputerMove();
                                    if (game.win)
                                    {
                                        WinnerLabel.Content = $"{game.Players[game.CurrentPlayerGoingIndex].PlayerName} has won";
                                        PlayerNameBox.Text = null;
                                        PlayerOneNameBox.Text = null;
                                        PlayerTwoNameBox.Text = null;
                                        GameBoardUI.Visibility = Visibility.Collapsed;
                                        PlayAgainMenu.Visibility = Visibility.Visible;
                                    }
                                }
                            }


                        }


                    }

                }
            }

        }

        /// <summary>
        /// This will take the user back to the main menu for a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            PlayAgainMenu.Visibility = Visibility.Collapsed;
            StartMenu.Visibility = Visibility.Visible;
            Rules.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// This method closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks For Playing");
            Environment.Exit(0);
        }
    }
}
