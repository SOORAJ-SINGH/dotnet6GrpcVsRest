using BenchmarkDotNet.Running;

namespace RESTvsGRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start..");
            //Console.ReadKey();


            BenchmarkRunner.Run<BenchmarkHarness>();
            Console.ReadKey();
        }
    }
}
