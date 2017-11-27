using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using static Project.GameBoard;

namespace UnitTests {
    [TestClass]
    public class GameBoardTest {
        [TestMethod]
        public void FieldIsTaken_Should_Return_True_When_A_Field_Is_Taken() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 1, 4);
            bool isEmpty = tic.FieldIsTaken(1, 4);
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void FieldIsTaken_Should_Return_False_When_The_Field_Is_Not_Taken() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 1, 4);
            bool isEmpty = tic.FieldIsTaken(3, 3);
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void PlaceChar_Should_Return_True_When_Char_Is_Placed_In_Empty_Field() {
            GameBoard tic = new GameBoard(5, 5);
            Assert.IsTrue(tic.PlaceChar(Piece.X, 1, 4));
        }

        [TestMethod]
        public void PlaceChar_Should_Place_Char_In_Correct_Location() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 1, 4);
            Assert.IsTrue(tic.Board[1, 4].Equals(Piece.X));
        }

        [TestMethod]
        public void PlaceChar_Should_Return_False_When_Field_Is_Taken() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.O, 1, 4);
            Assert.IsFalse(tic.PlaceChar(Piece.X, 1, 4));
        }

        [TestMethod]
        public void CheckVerticals_Should_Return_True_When_There_Is_A_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 0);
            tic.PlaceChar(Piece.X, 0, 1);
            tic.PlaceChar(Piece.X, 0, 2);
            tic.PlaceChar(Piece.X, 0, 3);
            tic.PlaceChar(Piece.X, 0, 4);
            Assert.IsTrue(tic.CheckVerticals(Piece.X));
            tic.PlaceChar(Piece.O, 4, 0);
            tic.PlaceChar(Piece.O, 4, 1);
            tic.PlaceChar(Piece.O, 4, 2);
            tic.PlaceChar(Piece.O, 4, 3);
            tic.PlaceChar(Piece.O, 4, 4);
            Assert.IsTrue(tic.CheckVerticals(Piece.O));
        }

        [TestMethod]
        public void CheckVerticals_Should_Return_False_When_There_Is_No_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 0);
            tic.PlaceChar(Piece.X, 0, 1);
            tic.PlaceChar(Piece.X, 0, 2);
            tic.PlaceChar(Piece.X, 0, 3);
            // tic.PlaceChar(Piece.X, 0, 4); this should remain commented out
            Assert.IsFalse(tic.CheckVerticals(Piece.X));
            // tic.PlaceChar(Piece.O, 4, 0); this should remain commented out
            tic.PlaceChar(Piece.O, 4, 1);
            tic.PlaceChar(Piece.O, 4, 2);
            tic.PlaceChar(Piece.O, 4, 3);
            tic.PlaceChar(Piece.O, 4, 4);
            Assert.IsFalse(tic.CheckVerticals(Piece.O));
        }

        [TestMethod]
        public void CheckHorizontals_Should_Return_True_When_There_Is_A_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 0);
            tic.PlaceChar(Piece.X, 1, 0);
            tic.PlaceChar(Piece.X, 2, 0);
            tic.PlaceChar(Piece.X, 3, 0);
            tic.PlaceChar(Piece.X, 4, 0);
            Assert.IsTrue(tic.CheckHorizontals(Piece.X));
            tic.PlaceChar(Piece.O, 0, 4);
            tic.PlaceChar(Piece.O, 1, 4);
            tic.PlaceChar(Piece.O, 2, 4);
            tic.PlaceChar(Piece.O, 3, 4);
            tic.PlaceChar(Piece.O, 4, 4);
            Assert.IsTrue(tic.CheckHorizontals(Piece.O));
        }

        [TestMethod]
        public void CheckHorizontals_Should_Return_False_When_There_Is_No_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 0);
            tic.PlaceChar(Piece.X, 1, 0);
            tic.PlaceChar(Piece.X, 2, 0); 
            tic.PlaceChar(Piece.X, 3, 0);
            //tic.PlaceChar(Piece.X, 4, 0); this should remain commented out
            Assert.IsFalse(tic.CheckHorizontals(Piece.X));
            // tic.PlaceChar(Piece.O, 0, 4); this should remain commented out
            tic.PlaceChar(Piece.O, 1, 4);
            tic.PlaceChar(Piece.O, 2, 4); 
            tic.PlaceChar(Piece.O, 3, 4);
            tic.PlaceChar(Piece.O, 4, 4);
            Assert.IsFalse(tic.CheckHorizontals(Piece.O));
        }

        [TestMethod]
        public void CheckDiagonalDownRight_Should_Return_True_When_There_Is_A_Win() {
            GameBoard tac = new GameBoard(5, 5);
            tac.PlaceChar(Piece.O, 0, 0);
            tac.PlaceChar(Piece.O, 1, 1);
            tac.PlaceChar(Piece.O, 2, 2);
            tac.PlaceChar(Piece.O, 3, 3);
            tac.PlaceChar(Piece.O, 4, 4);
            Assert.IsTrue(tac.CheckDiagonalDownRight(Piece.O));
        }

        [TestMethod]
        public void CheckDiagonalDownRight_Should_Return_False_When_There_Are_Is_No_Win() {
            GameBoard tac = new GameBoard(5, 5);
            tac.PlaceChar(Piece.O, 0, 0);
            tac.PlaceChar(Piece.O, 1, 1);
            // tac.PlaceChar(Piece.O, 2, 2); this should remain commented out
            tac.PlaceChar(Piece.O, 3, 3);
            tac.PlaceChar(Piece.O, 4, 4);
            Assert.IsFalse(tac.CheckDiagonalDownRight(Piece.O));
        }

        [TestMethod]
        public void CheckDiagonalUpRight_Should_Return_True_When_There_Is_A_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 4);
            tic.PlaceChar(Piece.X, 1, 3);
            tic.PlaceChar(Piece.X, 2, 2);
            tic.PlaceChar(Piece.X, 3, 1);
            tic.PlaceChar(Piece.X, 4, 0);
            Assert.IsTrue(tic.CheckDiagonalUpRight(Piece.X));
        }

        [TestMethod]
        public void CheckDiagonalUpRight_Should_Return_False_When_There_Are_Is_No_Win() {
            GameBoard tic = new GameBoard(5, 5);
            tic.PlaceChar(Piece.X, 0, 4);
            tic.PlaceChar(Piece.X, 1, 3);
            //tic.PlaceChar(Piece.X, 2, 2); this should remain commented out
            tic.PlaceChar(Piece.X, 3, 1);
            tic.PlaceChar(Piece.X, 4, 0);
            Assert.IsFalse(tic.CheckDiagonalUpRight(Piece.X));
        }

        [TestMethod]
        public void GetLengths() {
            GameBoard tic = new GameBoard(5, 4);
            tic.PlaceChar(Piece.X, 0, 0);
            Assert.IsTrue(tic.Board[0, 0].Equals(Piece.X));
            tic.PlaceChar(Piece.O, 0, 1);
            Assert.IsTrue(tic.Board[0, 1].Equals(Piece.O));
        }

        

        
    }
}
