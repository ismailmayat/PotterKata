using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using PotterDiscount;

namespace PotterBenchMark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn()]
    public class PotterBenchMark
    {
        private BookSetBuilder _bookSetBuilder;
        private readonly List<Book> _oneThousandBooks = new List<Book>();

        [GlobalSetup]
        public void Setup()
        {
            _bookSetBuilder = new BookSetBuilder(5);
            CreateOneThousandBooksFiveOfEach();
        }

        private void CreateOneThousandBooksFiveOfEach()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    _oneThousandBooks.Add(new Book(8M,i.ToString()+j.ToString()));
                }
            }
        }
        
        [Benchmark]
        public void PotterBasketOneThousandBooks()
        {
            _bookSetBuilder.Build(_oneThousandBooks);
        }
    }
}