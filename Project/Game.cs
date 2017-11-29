using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project {
    public class Game {

        private GameBoard _gameBoard;
        private Player _player1;
        private Player _player2;

        public Game(Player player1, Player player2) {
            _gameBoard = new GameBoard(5, 5);
        }

        public void Setup() {

        }
    }
}
