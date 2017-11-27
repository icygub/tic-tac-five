using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;

namespace UnitTests {
    [TestClass]
    public class BoardTest {
        [TestMethod]
        public void FieldIsTaken_Should_Return_True_When_A_Field_Is_Taken() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 1, 4);          
            bool isEmpty = tic.FieldIsTaken(1, 4);
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void FieldIsTaken_Should_Return_False_When_The_Field_Is_Not_Taken() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 1, 4);
            bool isEmpty = tic.FieldIsTaken(3, 3);
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void PlaceChar_Should_Return_True_When_Char_Is_Placed_In_Empty_Field() {
            TicTacFive tic = new TicTacFive(5, 5);           
            Assert.IsTrue(tic.PlaceChar('X', 1, 4));
        }

        [TestMethod]
        public void PlaceChar_Should_Place_Char_In_Correct_Location() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 1, 4);
            Assert.IsTrue(tic.Board[1, 4].Equals('X'));
        }

        [TestMethod]
        public void PlaceChar_Should_Return_False_When_Field_Is_Taken() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('O', 1, 4);
            Assert.IsFalse(tic.PlaceChar('X', 1, 4));
        }

        [TestMethod]
        public void CheckVerticals_Should_Return_True_When_There_Are_Consecutive_Chars_In_Same_Column() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 0, 0);
            tic.PlaceChar('X', 0, 1);
            tic.PlaceChar('X', 0, 2);
            tic.PlaceChar('X', 0, 3);
            tic.PlaceChar('X', 0, 4);
            Assert.IsTrue(tic.CheckVerticals('X'));
            tic.PlaceChar('O', 4, 0);
            tic.PlaceChar('O', 4, 1);
            tic.PlaceChar('O', 4, 2);
            tic.PlaceChar('O', 4, 3);
            tic.PlaceChar('O', 4, 4);
            Assert.IsTrue(tic.CheckVerticals('O'));
        }

        [TestMethod]
        public void CheckHorizontals_Should_Return_True_When_There_Are_Consecutive_Charss() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 0, 0);
            tic.PlaceChar('X', 1, 0);
            tic.PlaceChar('X', 2, 0);
            tic.PlaceChar('X', 3, 0);
            tic.PlaceChar('X', 4, 0);
            Assert.IsTrue(tic.CheckHorizontals('X'));
            tic.PlaceChar('O', 0, 4);
            tic.PlaceChar('O', 1, 4);
            tic.PlaceChar('O', 2, 4);
            tic.PlaceChar('O', 3, 4);
            tic.PlaceChar('O', 4, 4);
            Assert.IsTrue(tic.CheckHorizontals('O'));
        }

        [TestMethod]
        public void CheckDiagonalDownRight_Should_Return_True_When_There_Are_Consecutive_Chars() {
            TicTacFive tac = new TicTacFive(5, 5);
            tac.PlaceChar('O', 0, 0);
            tac.PlaceChar('O', 1, 1);
            tac.PlaceChar('O', 2, 2);
            tac.PlaceChar('O', 3, 3);
            tac.PlaceChar('O', 4, 4);
            Assert.IsTrue(tac.CheckDiagonalDownRight('O'));
        }

        [TestMethod]
        public void CheckDiagonalUpRight_Should_Return_True_When_There_Are_Consecutive_Chars() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 0, 4);
            tic.PlaceChar('X', 1, 3);
            tic.PlaceChar('X', 2, 2);
            tic.PlaceChar('X', 3, 1);
            tic.PlaceChar('X', 4, 0);
            Assert.IsTrue(tic.CheckDiagonalUpRight('X'));
        }

        [TestMethod]
        public void GetLengths() {
            TicTacFive tic = new TicTacFive(5, 4);
            tic.PlaceChar('X', 0, 0);
            Assert.IsTrue(tic.Board[0, 0].Equals('X'));
            tic.PlaceChar('O', 0, 1);
            Assert.IsTrue(tic.Board[0, 1].Equals('O'));
        }
        
        [TestMethod]
        public void CheckDiagonalUpRight_Should_Return_False_When_There_Are_No_Consecutive_Chars() {
            TicTacFive tic = new TicTacFive(5, 5);
            tic.PlaceChar('X', 0, 4);
            tic.PlaceChar('X', 1, 3);
            //tic.PlaceChar('X', 2, 2); this should remain commented out
            tic.PlaceChar('X', 3, 1);
            tic.PlaceChar('X', 4, 0);
            Assert.IsFalse(tic.CheckDiagonalUpRight('X'));
        }
        
        [TestMethod]
        public void CheckDiagonalDownRight_Should_Return_False_When_There_Are_No_Consecutive_Chars() {
            TicTacFive tac = new TicTacFive(5, 5);
            tac.PlaceChar('O', 0, 0);
            tac.PlaceChar('O', 1, 1);
            // tac.PlaceChar('O', 2, 2); this should remain commented out
            tac.PlaceChar('O', 3, 3);
            tac.PlaceChar('O', 4, 4);
            Assert.IsFalse(tac.CheckDiagonalDownRight('O'));
        }
        
        
        
    }
}
