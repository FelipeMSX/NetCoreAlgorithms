using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Collections;
using AlgorithmsTests;
using Algorithms.Exceptions;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class StaticQueueTests
    {

        //private StaticQueue<ObjectTest> _staticQueue;

        //private Comparison<ObjectTest> _comparisonObjectTest = ((x, y) =>
        // {
        //     if (x.Id > y.Id)
        //         return 1;
        //     else
        //     if (x.Id < y.Id)
        //         return -1;
        //     else
        //         return 0;
 
        // });

        //[TestInitialize]
        //public void Initialize()
        //{
        //    _staticQueue = new StaticQueue<ObjectTest>(100,true,_comparisonObjectTest);
        //}

        //[TestMethod, TestCategory("StaticQueue")]
        //public void Push_ThreeObjects_LengthEqualsThree()
        //{
        //    //Arrange --Configurado no Initialize
        //    //Act
        //    _staticQueue.Push(new ObjectTest("AAAA", 2));
        //    _staticQueue.Push(new ObjectTest("AAAA", 1));
        //    _staticQueue.Push(new ObjectTest("BBBB", 4));
        //    //Assert
        //    Assert.IsTrue(_staticQueue.Length == 3);
        //}

        //[TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(NullObjectException))]
        //public void Push_NullValue_NullObjectException()
        //{
        //    //Arrange --Configurado no Initialize
        //    //Act
        //    _staticQueue.Push(null);
        //    //Assert
        //    Assert.Inconclusive("Uma exceção do tipo NullObjectException deveria ter acontecido!");
        //}

        //[TestMethod, TestCategory("StaticQueue")]
        //public void Push_ObjectInFullCollectionResizable_LengthEqualsThree()
        //{
        //    //Arrange
        //    _staticQueue = new StaticQueue<ObjectTest>(2, true, _comparisonObjectTest);
        //    //Act
        //    _staticQueue.Push(new ObjectTest("AAAA", 1));
        //    _staticQueue.Push(new ObjectTest("BBBB", 2));
        //    _staticQueue.Push(new ObjectTest("CCCC", 3));
        //    //Assert
        //    //Por padrão, a capacidade da lista é aumentada em 100.
        //    Assert.IsTrue(_staticQueue.Length == 3 && _staticQueue.MaxSize == 102);
        //}

        //[TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(FullCollectionException))]

        //public void Push_ObjectInFullCollectionNotResizable_FullCollectionException()
        //{
        //    //Arrange
        //    _staticQueue = new StaticQueue<ObjectTest>(2, false, _comparisonObjectTest);
        //    //Act
        //    _staticQueue.Push(new ObjectTest("AAAA", 1));
        //    _staticQueue.Push(new ObjectTest("BBBB", 2));
        //    _staticQueue.Push(new ObjectTest("CCCC", 3)); // Deve ocorrer a exceção aqui.
        //    //Assert
        //    Assert.Inconclusive("Uma exceção do tipo FullCollectionException deveria ter acontecido!");
        //}


        //[TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(EmptyCollectionException))]
        //public void Pop_EmptyList_EmptyCollectionException()
        //{
        //    //Arrange
        //    //Act
        //    _staticQueue.Pop();
        //    //Assert
        //    Assert.Inconclusive("Uma exceção do tipo EmptyCollectionException deveria ter acontecido,pois, não existe nenhum elemento na coleção!");
        //}

        //[TestMethod, TestCategory("StaticQueue")]
        //public void Pop_InsertABC_RetriveABC()
        //{
        //    //Arrange
        //    _staticQueue.Push(new ObjectTest("AAAA", 1));
        //    _staticQueue.Push(new ObjectTest("BBBB", 2));       
        //    _staticQueue.Push(new ObjectTest("CCCC", 3));
        //    //Act
        //    ObjectTest popedObject1 = _staticQueue.Pop();
        //    ObjectTest popedObject2 = _staticQueue.Pop();
        //    ObjectTest popedObject3 = _staticQueue.Pop();
        //    //Assert
        //    Assert.IsTrue(popedObject1.Id == 1 && popedObject2.Id == 2 && popedObject3.Id == 3);

        //}
    }
}
