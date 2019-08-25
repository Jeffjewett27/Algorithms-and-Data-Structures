using System;
using System.Text;
using Algorithms_and_Data_Structures.DataStructures;

namespace Algorithms_and_Data_Structures.Algorithms
{
    /// <summary>
    /// The stock span problem accepts a list of stock values for particular days, and for each value,
    /// reports the number of consecutive prior days that stocks have been less than or equal to said stock
    /// The reported value is inclusive of the current value, and exclusive of the closest value larger
    /// </summary>
    public static class StockSpanProblem
    {
        public class Stock
        {
            public DateTime date;
            public double value;

            public Stock (DateTime date, double value)
            {
                this.date = date;
                this.value = value;
            }
        }

        public static int[] StockSpansNaive(Stock[] stocks)
        {
            var stockSpans = new int[stocks.Length];
            stockSpans[0] = 1;

            for (int i = 1; i < stocks.Length; i++)
            {
                Stock stock = stocks[i];
                int j = i - 1;

                while (j >= 0 && stocks[j].value <= stocks[i].value)
                {
                    j--;
                }

                Stock lastValue;
                int span;
                if (j == -1)
                {
                    lastValue = stocks[0];
                    span = 1 + (stock.date - lastValue.date).Days;
                }
                else
                {
                    lastValue = stocks[j];
                    span = (stock.date - lastValue.date).Days;
                }
                stockSpans[i] = span;
            }
            return stockSpans;
        }

        public static int[] StockSpans(Stock[] stocks)
        {
            var stockSpans = new int[stocks.Length];
            var topStocks = new Stack<Stock>();

            stockSpans[0] = 1;
            topStocks.Push(stocks[0]);

            for (int i = 1; i < stocks.Length; i++)
            {
                Stock stock = stocks[i];
                while (topStocks.HasNext() && stock.value >= topStocks.Peek().value)
                {
                    topStocks.Pop();
                }
                Stock lastValue;
                int span;
                if (topStocks.HasNext())
                {
                    lastValue = topStocks.Peek();
                    span = (stock.date - lastValue.date).Days;
                } else
                {
                    lastValue = stocks[0];
                    span = 1 + (stock.date - lastValue.date).Days;
                }
                stockSpans[i] = span;
                topStocks.Push(stock);
            }

            return stockSpans;
        }
    }
}
