using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;

namespace UnitTests {
    [TestClass]
    public class ViewModelTest {
        [TestMethod]
        public void PlayPiece_Should_Return_True_When_There_Is_A_Win() {
            ViewModel vm = new ViewModel();
            vm.PlayPiece(0, 0); // X
            vm.PlayPiece(1, 0); // O
            vm.PlayPiece(0, 1); // X
            vm.PlayPiece(2, 1); // O
            vm.PlayPiece(0, 2); // X
            vm.PlayPiece(3, 1); // O
            vm.PlayPiece(0, 3); // X
            vm.PlayPiece(2, 3); // O
            Assert.IsTrue(vm.PlayPiece(0, 4)); // X
        }

        [TestMethod]
        public void PlayPiece_Should_Return_False_When_There_Is_No_Win() {
            ViewModel vm = new ViewModel();
            Assert.IsFalse(vm.PlayPiece(0, 0)); // X
            Assert.IsFalse(vm.PlayPiece(1, 0)); // O
            Assert.IsFalse(vm.PlayPiece(0, 1)); // X
            Assert.IsFalse(vm.PlayPiece(2, 1)); // O
            Assert.IsFalse(vm.PlayPiece(0, 2)); // X
            Assert.IsFalse(vm.PlayPiece(3, 1)); // O
            Assert.IsFalse(vm.PlayPiece(0, 3)); // X
            Assert.IsFalse(vm.PlayPiece(2, 3)); // O
            
        }
    }
}
