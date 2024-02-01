using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
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

    public class CalculatorServiceBenchmarks
    {
        // Create a client with given client endpoint configuration
        private readonly CalculatorServiceClient _client = new();

        [Benchmark]
        public void Add() {

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = _client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
        }

        [Benchmark]
        public void Subtract() {
            // Call the Subtract service operation.
            double value1 = 145.00D;
            double value2 = 76.54D;
            double result = _client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);
        }

        [Benchmark]
        public void Multiply() {
            // Call the Multiply service operation.
            double value1 = 9.00D;
            double value2 = 81.25D;
            double result = _client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);
        }

        [Benchmark]
        public void Divide() {
            // Call the Divide service operation.
            double value1 = 22.00D;
            double value2 = 7.00D;
            double result = _client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
        }
    }
}
