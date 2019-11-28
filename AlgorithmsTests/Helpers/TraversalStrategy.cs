using Algorithms.Collections;
using Algorithms.Exceptions;
using Algorithms.Helpers.TreeHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Test.Helpers
{
    [TestClass]
    public class TraversalStrategy
    {
        private BinaryTreeCollection<int?> _binaryTree;


        [TestInitialize]
        public void TearUp()
        {
                    //TREE STRUCTURE
            /*
             *                  10
             *          3               20
             *      2       7
             *           6     8
             * 
             * 
             */

            _binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison);
            _binaryTree.Add(10);
            _binaryTree.Add(3);
            _binaryTree.Add(20);
            _binaryTree.Add(2);
            _binaryTree.Add(7);
            _binaryTree.Add(6);
            _binaryTree.Add(8);
        }



        [TestCleanup]
        public void TearDown()
        {
            _binaryTree = null;
        }

        #region InOrderTraversal

        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo nenhuma vez.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalInOrder_WhenEmptyCollection_True()
        {
            //Arrange
            BinaryTreeCollection<int?> binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison);
            //Act
            foreach (int? value in _binaryTree){}
            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo N vezes.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalInOrder_WhenFilledWithValues_ExpectedOrder()
        {
            //Arrange
            Stack<int?> expectedOrder = new Stack<int?>(new int?[] { 20, 10, 8, 7, 6, 3, 2 });

            //Act
            foreach (int? value in _binaryTree)
            {
                if(expectedOrder.Peek() == value)
                {
                    expectedOrder.Pop();
                }
            }

            //Assert
            Assert.IsTrue(expectedOrder.Count == 0, "The stack size expected was 0.");
        }

        #endregion

        #region PreOrderStrategy
        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo nenhuma vez.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalPreOrder_WhenEmptyCollection2_True()
        {
            //Arrange
            BinaryTreeCollection<int?> binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison, new PreOrderTraversal<int?>());
            //Act
            foreach (int? value in _binaryTree){}
            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo N vezes.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalPreOrder_WhenFilledWithValues_ExpectedOrder()
        {
            //Arrange
            Stack<int?> expectedOrder = new Stack<int?>(new int?[] { 20, 8, 6, 7, 2, 3, 10 });

            //TREE STRUCTURE
            /*
             *                  10
             *          3               20
             *      2       7
             *           6     8
             * 
             * 
             */
            _binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison, new PreOrderTraversal<int?>());
            _binaryTree.Add(10);
            _binaryTree.Add(3);
            _binaryTree.Add(20);
            _binaryTree.Add(2);
            _binaryTree.Add(7);
            _binaryTree.Add(6);
            _binaryTree.Add(8);

            //Act
            foreach (int? value in _binaryTree)
            {
                if (expectedOrder.Peek() == value)
                {
                    expectedOrder.Pop();
                }
            }

            //Assert
            Assert.IsTrue(expectedOrder.Count == 0, "The stack size expected was 0.");
        }

        #endregion

        #region PostOrderStrategy
        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo nenhuma vez.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalPostOrder_WhenEmptyCollection2_True()
        {
            //Arrange
            BinaryTreeCollection<int?> binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison, new PostOrderTraversal<int?>());
            //Act
            foreach (int? value in _binaryTree) { }
            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Técnica: Teste de Ciclo. Executar o ciclo N vezes.
        /// </summary>
        [TestMethod, TestCategory("TraversalStrategy")]
        public void TraversalPostOrder_WhenFilledWithValues_ExpectedOrder()
        {
            //Arrange
            Stack<int?> expectedOrder = new Stack<int?>(new int?[] { 10, 20, 3, 7, 8, 6, 2 });

            //TREE STRUCTURE
            /*
             *                  10
             *          3               20
             *      2       7
             *           6     8
             * 
             * 
             */
            _binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison, new PostOrderTraversal<int?>());
            _binaryTree.Add(10);
            _binaryTree.Add(3);
            _binaryTree.Add(20);
            _binaryTree.Add(2);
            _binaryTree.Add(7);
            _binaryTree.Add(6);
            _binaryTree.Add(8);

            //Act
            foreach (int? value in _binaryTree)
            {
                if (expectedOrder.Peek() == value)
                {
                    expectedOrder.Pop();
                }
            }

            //Assert
            Assert.IsTrue(expectedOrder.Count == 0, "The stack size expected was 0.");
        }

        #endregion

    }
}
