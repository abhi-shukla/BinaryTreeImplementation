using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeImplementation;

namespace BinaryTreeImplementation.Tests
{
    [TestClass]
    public class BTreeTests
    {
        [TestMethod]
        public void AddElementToEmptyTree_ShouldAddElementAsHead()
        {
            // Arrange
            var bTree = new BTree<int>();

            // Act
            bTree.Add(3);

            // Assert
            Assert.AreEqual(3, bTree._head.Value);
        }

        [TestMethod]
        public void AddElement_SmallerValueThanHead_ShouldAddElementToLeft()
        {
            // Arrange
            var bTree = new BTree<int>();
            bTree.Add(3);

            // Act
            bTree.Add(2);

            // Assert
            Assert.AreEqual(2, bTree._head.Left.Value);
        }

        [TestMethod]
        public void AddElement_LargerValueThanHead_ShouldAddElementToRight()
        {
            // Arrange
            var bTree = new BTree<int>();
            bTree.Add(3);

            // Act
            bTree.Add(4);

            // Assert
            Assert.AreEqual(4, bTree._head.Right.Value);
        }
    }
}
