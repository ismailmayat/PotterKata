using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PotterBenchMark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn()]
    public class PotterBenchMark
    {
        public void PotterBasketOneThousandBooks()
        {
            
        }
    }
}