using BenchmarkDotNet.Running;

namespace PotterBenchMark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<PotterBenchMark>();
        }
    }
}