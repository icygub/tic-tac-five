using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public class GameBoard {

        private Piece[,] _board;

        public GameBoard(int cols, int rows) {
            _board = new Piece[cols, rows];
            for (int col = 0; col < cols; col++) {
                for (int row = 0; row < rows; row++) {
                    _board[col, row] = Piece.EMPTY;
                }
            }
        }

        public Piece[,] Board {
            get { return _board; }
            private set { _board = value; }
        }

        public bool FieldIsTaken(int col, int row) {
            return !Board[col, row].Equals(Piece.EMPTY);
        }

        public bool PlaceChar(Piece p, int col, int row) {
            if (!FieldIsTaken(col, row)) {
                Board[col, row] = p;
                return true;
            }
            return false;
        }

        public bool CheckWin(Piece p) {
            bool win = false;
            if(CheckVerticals(p) || CheckHorizontals(p) || 
                CheckDiagonalUpRight(p) || CheckDiagonalDownRight(p)) {
                win = true;
            }
            return win;
        }

        public bool CheckVerticals(Piece p) {
            bool win = false;
            for (int col = 0; col < Board.GetLength(0); col++) { //Board.GetLength(0) is number of cols in Board
                for (int row = 0; row < Board.GetLength(1); row++) {
                    if (Board[col, row] != p) {
                        break;
                    }
                    else if (row == Board.GetLength(1) - 1) {
                        win = true;
                    }
                }
                if (win == true) {
                    break;
                }
            }
            return win;
        }

        public bool CheckHorizontals(Piece p) {
            bool win = false;
            for (int row = 0; row < Board.GetLength(1); row++) { //Board.GetLength(1) is number of rows in Board
                for (int col = 0; col < Board.GetLength(0); col++) {
                    if (Board[col, row] != p) {
                        break;
                    }
                    //if last col char matches 
                    else if (col == Board.GetLength(0) - 1) {
                        win = true;
                    }
                }
                if (win == true) {
                    break;
                }
            }
            return win;
        }

        public bool CheckDiagonalUpRight(Piece p) {
            bool win = false;
            int col = 0;
            // starts at [0,max] and ends at [max,0]
            for (int row = Board.GetLength(1) - 1; row >= 0; row--) {
                if (Board[col, row] != p) {
                    break;
                }
                else if (row == 0) {
                    win = true;
                }
                else {
                    col++;
                }
            }
            return win;
        }

        public bool CheckDiagonalDownRight(Piece p) {
            bool win = false;
            int col = 0;
            // starts at [0,0] and ends at [max,max]
            for (int row = 0; row < Board.GetLength(1); row++) {
                if (Board[col, row] != p) {
                    break;
                }
                else if (row == Board.GetLength(1) - 1) {
                    win = true;
                }
                else {
                    col++;
                }
            }
            return win;
        }

        public enum Piece {
            EMPTY, X, O
        }
    }
}
