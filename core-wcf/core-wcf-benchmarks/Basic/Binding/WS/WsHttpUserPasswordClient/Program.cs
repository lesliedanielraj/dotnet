// See https://aka.ms/new-console-template for more information

using System.ServiceModel;
using System.ServiceModel.Security;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using ServiceReference1;
using WsHttpUserPasswordClient;

BenchmarkSwitcher.FromAssembly(typeof(WsHttpBindingBenchmarks).Assembly).Run(args, new DebugInProcessConfig());

namespace WsHttpUserPasswordClient
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
    public class WsHttpBindingBenchmarks
    {
        private EchoServiceClient _client;
        
        [Benchmark]
        public async Task Testing_EchoAsync()
        {
            var wsHttpBindingWithCredential = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
            wsHttpBindingWithCredential.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            _client = new EchoServiceClient(wsHttpBindingWithCredential, new EndpointAddress("https://localhost:8443/EchoService/wsHttpUserPassword"));
            var up = _client.ClientCredentials.UserName;
            up.UserName = "ImValid";
            up.Password = "passwordIsValid";

            var cert = new X509ServiceCertificateAuthentication();
            cert.CertificateValidationMode = X509CertificateValidationMode.None;

            _client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = cert;

            await _client.OpenAsync();
            

            var files = new[] {
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ",
                // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV",
                // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_12345678"
            };
            Parallel.ForEach(files, file =>
            {
                _client.ComplexEchoAsync(new EchoMessage
                {
                    Text = file
                });
                
                // Console.WriteLine($"Hash: {hash}");
            });
            
            _client.Close();
        }
    }
}


