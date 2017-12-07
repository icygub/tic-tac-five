using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using static Project.GameBoard;

namespace UnitTests {
    [TestClass]
    public class GameTest {
        [TestMethod]
        public void PlayPiece_Should_Return_True_When_Playing_Pieces_On_Empty_Spaces() {
            Game game = new Game(true, true);
            Assert.IsTrue(game.PlayPiece(0, 0));          
            Assert.IsTrue(game.PlayPiece(0, 4));
            Assert.IsTrue(game.PlayPiece(1, 2));
            Assert.IsTrue(game.PlayPiece(1, 3));
            Assert.IsTrue(game.PlayPiece(2, 4));
            Assert.IsTrue(game.PlayPiece(2, 3));
            Assert.IsTrue(game.PlayPiece(3, 1));
            Assert.IsTrue(game.PlayPiece(3, 2));
            Assert.IsTrue(game.PlayPiece(4, 0));
            Assert.IsTrue(game.PlayPiece(4, 4));
            
        }

        [TestMethod]
        public void PlayPiece_Should_Return_False_When_Playing_Pieces_On_Taken_Spaces() {
            Game game = new Game(true, true);
            Assert.IsTrue(game.PlayPiece(0, 0));
            Assert.IsTrue(game.PlayPiece(1, 4));
            Assert.IsTrue(game.PlayPiece(2, 2));
            Assert.IsTrue(game.PlayPiece(3, 2));
            Assert.IsTrue(game.PlayPiece(4, 0));
            Assert.IsTrue(game.PlayPiece(4, 4));
            Assert.IsFalse(game.PlayPiece(0, 0));
            Assert.IsFalse(game.PlayPiece(1, 4));
            Assert.IsFalse(game.PlayPiece(2, 2));
            Assert.IsFalse(game.PlayPiece(3, 2));
            Assert.IsFalse(game.PlayPiece(4, 0));
            Assert.IsFalse(game.PlayPiece(4, 4));
        }

        [TestMethod]
        public void CurrentPlayer_Should_Alternate_After_Successful_PlayPiece() {
            Game game = new Game(true, true);
            // the initial current player is player1
            Assert.IsTrue(game.CurrentPlayer == game.Player1);
            game.PlayPiece(0, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
            game.PlayPiece(1, 4);
            Assert.IsTrue(game.CurrentPlayer == game.Player1);
            game.PlayPiece(2, 2);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
            game.PlayPiece(3, 2);
            Assert.IsTrue(game.CurrentPlayer == game.Player1);
            game.PlayPiece(4, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
            game.PlayPiece(4, 4);
            Assert.IsTrue(game.CurrentPlayer == game.Player1);
        }

        [TestMethod]
        public void CurrentPlayer_Should_Not_Alternate_After_Failed_PlayPiece() {
            Game game = new Game(true, true);
            // the initial current player is player1
            game.PlayPiece(0, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
            game.PlayPiece(0, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);

            game.PlayPiece(2, 2);
            Assert.IsTrue(game.CurrentPlayer == game.Player1);
            game.PlayPiece(2, 2);
            Assert.IsTrue(game.CurrentPlayer == game.Player1);

            game.PlayPiece(4, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
            game.PlayPiece(4, 0);
            Assert.IsTrue(game.CurrentPlayer == game.Player2);
        }
    }
}
