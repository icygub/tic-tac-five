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
    }
}
