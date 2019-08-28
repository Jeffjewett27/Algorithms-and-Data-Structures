

using System;
using System.Text;
using Algorithms_and_Data_Structures.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureAlgorithmsTest.DataStructures
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void StackTest1()
        {
            var stack = new Stack<int>();
            int buffer = 1000;

            for (int i = 0; i < buffer; i++)
            {
                stack.Push(i);
            }

            int testedSum = 0;
            for (int i = 0; i < buffer; i++)
            {
                testedSum += stack.Pop();
            }

            int realSum = 0;
            for (int i = 0; i < buffer; i++)
            {
                realSum += i;
            }

            Assert.AreEqual(realSum, testedSum);
        }
    }
}
