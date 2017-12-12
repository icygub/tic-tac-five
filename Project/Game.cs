using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.GameBoard;

namespace Project {
    public class Game {

        private GameBoard _gameBoard;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        public Game(bool player1Human, bool player2Human) {
            GameBoard = new GameBoard(5, 5);
            if(player1Human) {
                Player1 = new HumanPlayer(Piece.X);
            } else {
                Player1 = new ComputerPlayer(Piece.X);
            }
            if(player2Human) {
                Player2 = new HumanPlayer(Piece.O);
            } else {
                Player2 = new ComputerPlayer(Piece.O);
            }
            CurrentPlayer = Player1;
        }

        public Game(bool player1Computer, bool player2Computer, bool player1X) {
            GameBoard = new GameBoard(5, 5);
            if (player1Computer) {
                Player1 = new ComputerPlayer();
            }
            else {
                Player1 = new HumanPlayer();
            }
            if (player2Computer) {
                Player2 = new ComputerPlayer();
            }
            else {
                Player2 = new HumanPlayer();
            }

            Player1.Piece = (player1X) ? Piece.X : Piece.O;
            Player2.Piece = (player1X) ? Piece.O : Piece.X;
            if(Player1.Piece == Piece.X) {
                CurrentPlayer = Player1;
            } else {
                CurrentPlayer = Player2;
            }
            
        }

        public Game(string player1name, bool player1Computer, string player2name, bool player2Computer, bool player1X) {
            GameBoard = new GameBoard(5, 5);
            if (player1Computer) {
                Player1 = new ComputerPlayer(player1name);
            }
            else {
                Player1 = new HumanPlayer(player1name);
            }
            if (player2Computer) {
                Player2 = new ComputerPlayer(player2name);
            }
            else {
                Player2 = new HumanPlayer(player2name);
            }

            Player1.Piece = (player1X) ? Piece.X : Piece.O;
            Player2.Piece = (player1X) ? Piece.O : Piece.X;
            if (Player1.Piece == Piece.X) {
                CurrentPlayer = Player1;
            }
            else {
                CurrentPlayer = Player2;
            }

        }

        public Game(Player player1, Player player2) {
            GameBoard = new GameBoard(5, 5);
            //_player1 = ()
            CurrentPlayer = Player1;
        }

        public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        public GameBoard GameBoard { get => _gameBoard; set => _gameBoard = value; }
        public Player Player1 { get => _player1; set => _player1 = value; }
        public Player Player2 { get => _player2; set => _player2 = value; }

        public bool PlayPiece(Player player, int col, int row) {
            bool success = false;
            if(player == CurrentPlayer) {
                success = player.PlacePiece(GameBoard, col, row);
                if(success == true) {
                    //changes the current piece if the other piece was played successfully
                    CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
                }
            }
            return success;
        }

        public bool PlayPieceNoAlternate(int col, int row) {       
            return CurrentPlayer.PlacePiece(GameBoard, col, row);
        }

        // do not modify this method
        public bool PlayPiece(int col, int row) {
            bool success = CurrentPlayer.PlacePiece(GameBoard, col, row);        
            if (success == true) {
                //changes the current piece if the other piece was played successfully
                AlternatePlayer();
            }
            return success;
        }

        //public bool PlayPiece(int col, int row) {
        //    bool success = CurrentPlayer.PlacePiece(GameBoard, col, row);
        //    if (success == true) {
        //        //changes the current piece if the other piece was played successfully
        //        AlternatePlayer();
        //    }
        //    return success;
        //}

        public void AlternatePlayer() {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }

        public bool CheckWin() {
            return GameBoard.CheckWin(CurrentPlayer.Piece);
        }

        public bool Play(int col, int row) {
            bool continuePlaying;
            CurrentPlayer.PlacePiece(GameBoard, col, row);
            continuePlaying = !CheckWin();
            if(continuePlaying) {
                //changes the current piece if the other piece was played successfully
                AlternatePlayer();
            }
            return continuePlaying;
        }


    }
}
