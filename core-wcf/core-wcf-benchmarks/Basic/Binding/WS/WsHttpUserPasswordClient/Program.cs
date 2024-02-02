// See https://aka.ms/new-console-template for more information
using System.ServiceModel;
using System.ServiceModel.Security;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(WsHttpBindingBenchmarks).Assembly).Run(args, new DebugInProcessConfig());

[CsvExporter]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
// [SimpleJob(RuntimeMoniker.NativeAot60)]
// [SimpleJob(RuntimeMoniker.NativeAot70)]
// [SimpleJob(RuntimeMoniker.NativeAot80)]
public class WsHttpBindingBenchmarks
{
        [Benchmark]
        public async Task Testing_EchoAsync()
        {
             ServiceReference1.EchoServiceClient _client;
             var wsHttpBindingWithCredential = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
             wsHttpBindingWithCredential.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
             _client = new ServiceReference1.EchoServiceClient(wsHttpBindingWithCredential, new EndpointAddress("https://localhost:8443/EchoService/wsHttpUserPassword"));
                var up = _client.ClientCredentials.UserName;
                up.UserName = "ImValid";
                up.Password = "passwordIsValid";

                var cert = new X509ServiceCertificateAuthentication();
                cert.CertificateValidationMode = X509CertificateValidationMode.None;

                _client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = cert;

                await _client.OpenAsync();
                var result = await _client.EchoAsync("An authenticated request");
                await _client.CloseAsync();
                
                Console.WriteLine(result);
        }
}


