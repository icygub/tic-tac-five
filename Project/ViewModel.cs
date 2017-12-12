using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public class ViewModel {

        private Game _game;

        public ViewModel() {
            //Game = new Game(true, true);
        }

        public Game Game { get => _game; set => _game = value; } 

        public void CreateGame(bool isPlayer1Computer, bool isPlayer2Computer, bool isPlayer1X) {
            Game = new Game(isPlayer1Computer, isPlayer2Computer, isPlayer1X);
        }

        public void CreateGame(string player1name, bool isPlayer1Computer, string player2name, bool isPlayer2Computer, bool isPlayer1X) {
            Game = new Game(player1name, isPlayer1Computer, player2name, isPlayer2Computer, isPlayer1X);

        }

        public bool PlayPiece(int col, int row) {
            //bool win = false;
            if(CheckWin()) {
                return false;
            }
            bool success = Game.PlayPieceNoAlternate(col, row);
            if (success && !CheckWin()) {
                Game.AlternatePlayer();
            }
            //win = Game.CheckWin();
            //if (!win) { // when win == false
            //    Game.AlternatePlayer();
            //}
            //return win;
            return success;
        }

        public bool CheckWin() {
            return _game.CheckWin();
        }

    }
}
