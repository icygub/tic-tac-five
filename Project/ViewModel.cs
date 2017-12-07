using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public class ViewModel {

        private Game _game;

        public ViewModel() {
            Game = new Game(true, true);
        }

        public Game Game { get => _game; set => _game = value; }

        public bool PlayPiece(int col, int row) {
            bool win = false;
            bool success = Game.PlayPieceNoAlternate(col, row);
            if(success) {
                win = Game.CheckWin();
                if (!win) { // when win == false
                    Game.AlternatePlayer();
                }
            }    
            return win;
        }

    }
}
