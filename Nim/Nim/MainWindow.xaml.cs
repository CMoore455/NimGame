using Nim.Converters;
using Nim.Models;
using System;
using System.Collections.Generic;
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
            List<List<Piece>> pieces = new List<List<Piece>>();
            for(int i = 0; i < game.Rows; i++)
            {
                pieces.Add(new List<Piece>());
                for (int j = 0; j < game.Columns; j++)
                {
                    Label l = new Label();
                    Piece p = new Piece();
                    pieces[i].Add(p);
                    l.SetValue(Grid.RowProperty, i);
                    l.SetValue(Grid.ColumnProperty, j);                       
                    LabelBinding(l, p);
                    GameBoardUI.Children.Add(l);
                }
            }
            game.gameBoard.BoardState = pieces;
        }

        public void LabelBinding(Label l, Piece p)
        {
            BoolToBrushConverter converter = new BoolToBrushConverter();
            l.DataContext = p;
            Binding b = new Binding("IsRemoved");
            b.Converter = converter;
            l.SetBinding(Label.BackgroundProperty, b);
        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            game.Rows = 2;
            game.Columns = 2;
            MakeGameBoard();
            DifficultyMenu.Visibility = Visibility.Collapsed;
            GameBoardUI.Visibility = Visibility.Visible;
            game.gameBoard.BoardState[0][1].IsRemoved = true;
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
    }
}
