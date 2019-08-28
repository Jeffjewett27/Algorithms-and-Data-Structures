using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms_and_Data_Structures.DataStructures;

namespace DataStructureAlgorithmsTest.DataStructures
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void QueueTest1()
        {
            int defaultBuffer = 1000;
            var queue = new Queue<int>();

            for (int i = 0; i < defaultBuffer; i++)
            {
                queue.Enqueue(i);
            }

            int queueSum = 0;
            for (int j = 0; j < 314; j++)
            {
                queueSum += queue.Dequeue();
            }

            int realSum = 0;
            for (int k = 0; k < 314; k++)
            {
                realSum += k;
            }

            Assert.AreEqual(realSum, queueSum);
        }
    }
}
