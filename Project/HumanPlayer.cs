using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public sealed class HumanPlayer : Player {

        public HumanPlayer(GameBoard.Piece p, string name) : base(p, name) {

        }

        public HumanPlayer(string name) : base(name) {

        }

        public HumanPlayer(GameBoard.Piece p) : base(p) {

        }

        public HumanPlayer() : base() {

        }

        public override bool PlacePiece(GameBoard board, int col, int row) {
            return board.PlaceChar(Piece, col, row);
        }
    }
}
