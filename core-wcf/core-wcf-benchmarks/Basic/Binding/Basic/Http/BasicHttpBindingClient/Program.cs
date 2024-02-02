using BasicHttpBindingClient.CalculatorService;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using CoreWcf.Samples.Http;

namespace BasicHttpBindingClient
{
    //The service contract is defined using Connected Service "WCF Web Service", generated from the service by the dotnet svcutil tool.

    //Client implementation code.
    public class Client
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Client).Assembly).Run(args, new DebugInProcessConfig());
    }

    [CsvExporter]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.NativeAot60)]
    [SimpleJob(RuntimeMoniker.NativeAot70)]
    [SimpleJob(RuntimeMoniker.NativeAot80)]
    public class CalculatorServiceBenchmarks
    {
        // Create a client with given client endpoint configuration
        private readonly CalculatorServiceClient _client = new();
    
        [Benchmark]
        public void Add() {
    
            var value1 = 100.00D;
            var value2 = 15.99D;
            _client.Add(value1, value2);
        }
    
        [Benchmark]
        public void Subtract() {
            var value1 = 145.00D;
            var value2 = 76.54D;
            _client.Subtract(value1, value2);
        }
    
        [Benchmark]
        public void Multiply() {
            var value1 = 9.00D;
            var value2 = 81.25D;
            _client.Multiply(value1, value2);
        }
    
        [Benchmark]
        public void Divide() {
            var value1 = 22.00D;
            var value2 = 7.00D;
            _client.Divide(value1, value2);
        }
    }
    
    [CsvExporter]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.NativeAot60)]
    [SimpleJob(RuntimeMoniker.NativeAot70)]
    [SimpleJob(RuntimeMoniker.NativeAot80)]
    public class SearchServiceBenchmarks
    {
        // Create a client with given client endpoint configuration
        private readonly SearchServiceClient _client = new();
    
        [Benchmark]
        public void FindSimpleAsync()
        {
            _client.FindSimpleAsync(5);
        }
    
        [Benchmark]
        public void Find_Generic_128_Async() {
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            _client.Find_Generic_128_Async(data, 5);
        }
        
        [Benchmark]
        public void Find_Generic_256_Async() {
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            _client.Find_Generic_256_Async(data, 5);
        }
    }
}
