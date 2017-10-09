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
        
        public MainWindow()
        {
            InitializeComponent();

        }
        public void MakeGameBoard()
        {
            ObservableCollection<ObservableCollection<Piece>> pieces = new ObservableCollection<ObservableCollection<Piece>>();
            for(int i = 0; i < game.Rows; i++)
            {
                pieces.Add( new ObservableCollection<Piece>());
                for (int j = 0; j < game.Columns; j++)
                {
                    Piece p = new Piece();
                    pieces[i].Add(p);               
                }
            }
            game.gameBoard.BoardState = pieces;

        }

        //public void LabelBinding(Label l, Piece p)
        //{

        //}

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            game.Rows = 2;
            game.Columns = 2;
            MakeGameBoard();
            Row1ListBox.ItemsSource = game.gameBoard.BoardState[0];
            Row2ListBox.ItemsSource = game.gameBoard.BoardState[1];
            DifficultyMenu.Visibility = Visibility.Collapsed;
            GameBoardUI.Visibility = Visibility.Visible;
            Row3ListBox.Visibility = Visibility.Collapsed;
            Row4ListBox.Visibility = Visibility.Collapsed;
            
        }

        private void PVCNameEnterButton_Click(object sender, RoutedEventArgs e)
        {
            PVCNameMenu.Visibility = Visibility.Collapsed;
            DifficultyMenu.Visibility = Visibility.Visible;
        }

        private void PVCButton_Click(object sender, RoutedEventArgs e)
        {
            StartMenu.Visibility = Visibility.Collapsed;
            PVCNameMenu.Visibility = Visibility.Visible;
        }

        private void TakeButton_Click(object sender, RoutedEventArgs e)
        {
            int piecesAvailable= 0;
            int piecesToTake = 0;
            int rowPicked = 0;
            if (!int.TryParse(WhichRowTextBox.Text, out rowPicked))
            {
                MessageBox.Show("Enter in a valid number");
            }
            else
            {
                for(int i = 0; i < game.gameBoard.BoardState[rowPicked].Count; i++)
                {
                    if(game.gameBoard.BoardState[rowPicked][i].IsRemoved == false)
                    {
                        piecesAvailable++;
                    }
                }

                if(!int.TryParse(HowManyPiecesTextBox.Text, out piecesToTake))
                {
                    MessageBox.Show("Enter in a valid number");
                }
                else
                {
                    game.HumanPlayerMove(rowPicked, piecesToTake);
                }
            }

        }

        private void MedButton_Click(object sender, RoutedEventArgs e)
        {
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
            Row4ListBox.Visibility = Visibility.Collapsed;

        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
