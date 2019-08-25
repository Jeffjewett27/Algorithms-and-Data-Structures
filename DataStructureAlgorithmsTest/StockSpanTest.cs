using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms_and_Data_Structures.Algorithms;
using System;
using System.Linq;

namespace DataStructureAlgorithmsTest
{
    [TestClass]
    public class StockSpanTest
    {
        [TestMethod]
        public void StockSpan1()
        {
            int numStocks = 8;
            var stocks = new StockSpanProblem.Stock[numStocks];
            stocks[0] = new StockSpanProblem.Stock(new DateTime(2019, 8, 24), 12);
            stocks[1] = new StockSpanProblem.Stock(new DateTime(2019, 8, 25), 14);
            stocks[2] = new StockSpanProblem.Stock(new DateTime(2019, 8, 26), 15);
            stocks[3] = new StockSpanProblem.Stock(new DateTime(2019, 8, 27), 12);
            stocks[4] = new StockSpanProblem.Stock(new DateTime(2019, 8, 28), 10);
            stocks[5] = new StockSpanProblem.Stock(new DateTime(2019, 8, 29), 8);
            stocks[6] = new StockSpanProblem.Stock(new DateTime(2019, 8, 30), 10);
            stocks[7] = new StockSpanProblem.Stock(new DateTime(2019, 8, 31), 14);

            var realStockSpans = new int[8] { 1, 2, 3, 1, 1, 1, 3, 5 };

            var testedStockSpans = StockSpanProblem.StockSpans(stocks);

            Assert.IsTrue(realStockSpans.SequenceEqual(testedStockSpans));
        }

        [TestMethod]
        public void StockSpan2()
        {
            int numStocks = 8;
            var stocks = new StockSpanProblem.Stock[numStocks];
            stocks[0] = new StockSpanProblem.Stock(new DateTime(2019, 8, 24), 12);
            stocks[1] = new StockSpanProblem.Stock(new DateTime(2019, 8, 26), 14);
            stocks[2] = new StockSpanProblem.Stock(new DateTime(2019, 8, 29), 15);
            stocks[3] = new StockSpanProblem.Stock(new DateTime(2019, 8, 30), 12);
            stocks[4] = new StockSpanProblem.Stock(new DateTime(2019, 9, 2), 10);
            stocks[5] = new StockSpanProblem.Stock(new DateTime(2019, 9, 6), 8);
            stocks[6] = new StockSpanProblem.Stock(new DateTime(2019, 9, 7), 10);
            stocks[7] = new StockSpanProblem.Stock(new DateTime(2019, 9, 8), 14);

            var realStockSpans = new int[8] { 1, 3, 6, 1, 3, 4, 8, 10 };

            var testedStockSpans = StockSpanProblem.StockSpans(stocks);

            Assert.IsTrue(realStockSpans.SequenceEqual(testedStockSpans));
        }

        [TestMethod]
        public void StockSpanNaive()
        {
            int numStocks = 8;
            var stocks = new StockSpanProblem.Stock[numStocks];
            stocks[0] = new StockSpanProblem.Stock(new DateTime(2019, 8, 24), 12);
            stocks[1] = new StockSpanProblem.Stock(new DateTime(2019, 8, 26), 14);
            stocks[2] = new StockSpanProblem.Stock(new DateTime(2019, 8, 29), 15);
            stocks[3] = new StockSpanProblem.Stock(new DateTime(2019, 8, 30), 12);
            stocks[4] = new StockSpanProblem.Stock(new DateTime(2019, 9, 2), 10);
            stocks[5] = new StockSpanProblem.Stock(new DateTime(2019, 9, 6), 8);
            stocks[6] = new StockSpanProblem.Stock(new DateTime(2019, 9, 7), 10);
            stocks[7] = new StockSpanProblem.Stock(new DateTime(2019, 9, 8), 14);

            var realStockSpans = new int[8] { 1, 3, 6, 1, 3, 4, 8, 10 };

            var testedStockSpans = StockSpanProblem.StockSpans(stocks);

            Assert.IsTrue(realStockSpans.SequenceEqual(testedStockSpans));
        }
    }
}
