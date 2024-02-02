using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using WebHttpBindingClient;
using WebHttpClient;

BenchmarkSwitcher.FromAssembly(typeof(WebHttpBindingBenchmarks).Assembly).Run(args, new DebugInProcessConfig());

namespace WebHttpBindingClient
{
    [CsvExporter]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
// [SimpleJob(RuntimeMoniker.NativeAot60)]
// [SimpleJob(RuntimeMoniker.NativeAot70)]
// [SimpleJob(RuntimeMoniker.NativeAot80)]
    public class WebHttpBindingBenchmarks
    {
        // Using a wrapper generated based on the service OpenAPI definition
        private readonly WebAPIGeneratedWrapper _client;

        public WebHttpBindingBenchmarks()
        {
            // Use a single HttpClient instance for multiple requests as it will pool connections
            HttpClient httpClient = new();
        
            _client = new WebAPIGeneratedWrapper("http://localhost:8080/", httpClient);
        }

        [Benchmark]
        public async Task Testing_the_path_endpoint() {

            // Calls /api/path/{param}
            var result = await _client.PathAsync("Testing_the_path_endpoint");
            Console.WriteLine(result);
        }

        [Benchmark]
        public async Task Testing_the_query_endpoint() {
            // Calls /api/query?param=value
            var result = await _client.QueryAsync("Testing_the_query_endpoint");
            Console.WriteLine(result);
        }

        [Benchmark]
        public async Task Testing_Complex_Contract() {
            // Calls /api/body with a complex data structure
            var data = CreateExampleContract();
            var result2 = await _client.BodyAsync(data);
            Console.WriteLine(JsonSerialize(result2));
        }
    
        ExampleContract CreateExampleContract()
        {
            return new ExampleContract()
            {
                SimpleProperty = "House Stark",
                ComplexProperty = new () { Name = "Jon Snow" },
                SimpleCollection = "Winter is coming".Split(" "),
                ComplexCollection = new ExampleContractArrayInnerContract[] { new() { Name = "Arya Stark" }, new() { Name = "Sansa Stark" } }
            };
        }

        string JsonSerialize<T>(T thing)
        {
            var jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            var sw = new StringWriter();
            var writer = new Newtonsoft.Json.JsonTextWriter(sw);
            writer.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonSerializer.Serialize(writer, thing);
            return sw.ToString();
        }
    }
}



