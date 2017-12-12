using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public sealed class ComputerPlayer : Player {

        public ComputerPlayer(string name) : base(name) {

        }

        public ComputerPlayer(GameBoard.Piece p, string name) : base(p, name) {

        }

        public ComputerPlayer(GameBoard.Piece p) : base(p) {
        }

        public ComputerPlayer() : base() {

        }

        public override bool PlacePiece(GameBoard board, int col, int row) {
            throw new NotImplementedException();
            // will need to program this so that the computer can
            // randomly select a cell to place a piece on
        }
    }
}
