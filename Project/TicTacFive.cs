using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public class TicTacFive {

        private char[,] _board;
        
        public TicTacFive(int cols, int rows) {
            _board = new char[cols, rows];
            for(int col = 0; col < cols; col++) {
                for(int row = 0; row < rows; row++) {
                    _board[col, row] = ' ';
                }
            }
        }

        public char[,] Board {
            get { return _board; }
            private set { _board = value; }
        }

        public bool FieldIsTaken(int col, int row) {
            return !Board[col, row].Equals(' ');
        }

        public bool PlaceChar(char c, int col, int row) {
            if(! FieldIsTaken(col,row)) {
                Board[col, row] = c;
                return true;
            }
            return false;
        }

        
    }
}
