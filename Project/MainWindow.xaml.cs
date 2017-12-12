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
        private Brush XBrush;
        private Brush OBrush;
        private Brush currentBrush;

        public MainWindow() {
            InitializeComponent();
            viewModel = new ViewModel();
            currentPiece = Piece.X;
            XBrush = Brushes.Orange;
            OBrush = Brushes.Purple;
            currentBrush = XBrush;            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(viewModel.Game.CurrentPlayer.Name);
            int col = Int32.Parse(((Button)sender).Name.Substring(1, 1));
            int row = Int32.Parse(((Button)sender).Name.Substring(2, 1));
            bool piecePlayed = viewModel.PlayPiece(col, row); // if there is no win, then piecePlayed will be true
            if(piecePlayed) {
                ((Button)sender).Content = Enum.GetName(typeof(Piece), currentPiece);
                ((Button)sender).Background = currentBrush;
                if(currentBrush == OBrush) {
                    ((Button)sender).Foreground = Brushes.White;
                }
                //Focus();
                //((Button)sender).IsFocused = false;
                currentBrush = (currentBrush == XBrush) ? OBrush: XBrush;
                if (! viewModel.CheckWin()) {
                    currentPiece = (currentPiece == Piece.X) ? Piece.O : Piece.X;
                } else {
                    MessageBox.Show(Enum.GetName(typeof(Piece), currentPiece) + " has WON!" + viewModel.Game.CurrentPlayer.Name +
                        viewModel.Game.CurrentPlayer.Piece);
                }
            } else if(viewModel.CheckWin()) {
                MessageBox.Show(Enum.GetName(typeof(Piece), currentPiece) + " has WON!" + viewModel.Game.CurrentPlayer.Name +
                    viewModel.Game.CurrentPlayer.Piece);
            }

            //Enum.GetName(typeof(Piece), Piece.X);
            //MessageBox.Show(col + " " + row);
        }

        private void startButton_Click(object sender, RoutedEventArgs e) {
            string player1NameString = player1Name.Text;
            string player2NameString = player2Name.Text;
            viewModel.CreateGame(player1NameString, isPlayer1Computer.IsChecked ?? false, player2NameString, isPlayer2Computer.IsChecked ?? false, player1IsX.IsChecked ?? false);
            resetButton.IsEnabled = true;
            startButton.IsEnabled = false;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e) {
            //gameGrid.InvalidateVisual();
            //infoGrid.InvalidateVisual();
        }
    }
}
