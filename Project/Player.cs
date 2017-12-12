using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.GameBoard;

namespace Project {
    public abstract class Player {

        
        private Piece _piece;
        private String _name;

        public Player(Piece piece, string name) {
            Piece = piece;
            Name = name;
        }

        public Player(string name) {
            Name = name;
        }

        public Player(Piece piece) {
            Piece = piece;
        }

        public Player() {

        }

        public Piece Piece {
            get {
                return _piece;
            }
            set {
                _piece = value;
            }
        }

        public string Name { get => _name; set => _name = value; }

        public abstract bool PlacePiece(GameBoard board, int col, int row);
    
    }
}