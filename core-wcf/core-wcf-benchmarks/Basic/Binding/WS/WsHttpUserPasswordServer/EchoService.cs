using System.Security.Cryptography;
using System.Text;
using CoreWCF;

namespace WsHttpUserPasswordServer;

[ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple)]
public class EchoService : IEchoService
{
    public string Echo(string text)
    {
        System.Console.WriteLine($"Received {text} from client!");
        return text;
    }

    public string ComplexEcho(EchoMessage text)
    {
        var hash = GetHash(text.Text).ToString();
        System.Console.WriteLine($"Received {text.Text} from client! Hash: {hash}");
        return hash;
    }
    
    public static byte[] GetHash(string inputString)
    {
        using (HashAlgorithm algorithm = SHA256.Create())
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public string FailEcho(string text)
        => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

    [AuthorizeRole("CoreWCFGroupAdmin")]
    public string EchoForPermission(string echo)
    {
        return echo;
    }
}