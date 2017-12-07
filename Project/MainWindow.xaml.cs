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
using static Project.GameBoard;

namespace Project {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ViewModel viewModel;
        private Piece currentPiece;

        public MainWindow() {
            InitializeComponent();
            viewModel = new ViewModel();
            currentPiece = Piece.X;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            int col = Int32.Parse(((Button)sender).Name.Substring(1, 1));
            int row = Int32.Parse(((Button)sender).Name.Substring(2, 1));
            bool piecePlayed = viewModel.PlayPiece(col, row); // if there is no win, then piecePlayed will be true
            if(piecePlayed) {
                ((Button)sender).Content = Enum.GetName(typeof(Piece), currentPiece);
                if (! viewModel.CheckWin()) {
                    currentPiece = (currentPiece == Piece.X) ? Piece.O : Piece.X;
                } else {
                    MessageBox.Show(Enum.GetName(typeof(Piece), currentPiece) + " has WON!");
                }
            } else if(viewModel.CheckWin()) {
                MessageBox.Show(Enum.GetName(typeof(Piece), currentPiece) + " has WON!");
            }

            //Enum.GetName(typeof(Piece), Piece.X);
            //MessageBox.Show(col + " " + row);
        }
    }
}
