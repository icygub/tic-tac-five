using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.GameBoard;

namespace Project {
    public abstract class Player {

        
        private Piece _piece;

        public Player(Piece piece) {
            Piece = piece;
        }

        public Piece Piece {
            get {
                return _piece;
            }
            set {
                _piece = value;
            }
        }

        public abstract bool PlacePiece(GameBoard board, int col, int row);
    
    }
}