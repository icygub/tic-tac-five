using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.GameBoard;

namespace Project {
    public abstract class Player {

        private string _name;
        private Piece _piece;

        public Player(string name) {
            Name = name;
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        public Piece Piece {
            get {
                return _piece;
            }
            set {
                _piece = value;
            }
        }
    }
}
