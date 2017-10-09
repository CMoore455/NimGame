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
            for(int i = 0; i < game.Rows; i++)
            {
                for(int j = 0; j < game.Columns; j++)
                {
                    Label l = new Label
                }
            }
        }
    }
}
