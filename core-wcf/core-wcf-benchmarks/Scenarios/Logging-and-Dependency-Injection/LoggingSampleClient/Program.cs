// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(LoggingSampleBenchmarks).Assembly).Run(args, new DebugInProcessConfig());

[CsvExporter]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
// [SimpleJob(RuntimeMoniker.NativeAot60)]
// [SimpleJob(RuntimeMoniker.NativeAot70)]
// [SimpleJob(RuntimeMoniker.NativeAot80)]
public class LoggingSampleBenchmarks
{
    // Using a wrapper generated based on the service OpenAPI definition
    private readonly ServiceReference1.ServiceClient _client;
    
    public LoggingSampleBenchmarks()
    {
        //Using a wrapper generated using Add Service Reference in Visual Studio
        _client = new ServiceReference1.ServiceClient();
    }

    [Benchmark]
    public async Task Testing_GetDataAsync()
    {
        var result = await _client.GetDataAsync(new Random().Next(100));
        Console.WriteLine($"The result for GetDataAsync() is {result}");
    }
    
    [Benchmark]
    public async Task Testing_GetDataUsingDataContractAsync()
    {
        var client2 = new ServiceReference2.Service2Client();
        var obj = new ServiceReference2.CompositeType() { BoolValue = true, StringValue = "Mary had a little lamb" };
        var result2 = await client2.GetDataUsingDataContractAsync(obj);
        Console.WriteLine($"The results are :- BoolValue: {result2.BoolValue}, StringValue: \"{result2.StringValue}\"");
    }
}