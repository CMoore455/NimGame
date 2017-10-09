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
            game.gameBoard.BoardState[0].RemoveAt(game.gameBoard.BoardState[0].Count - 1);
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameBoard.BoardState[0].RemoveAt(game.gameBoard.BoardState[0].Count - 1);
        }
    }
}
