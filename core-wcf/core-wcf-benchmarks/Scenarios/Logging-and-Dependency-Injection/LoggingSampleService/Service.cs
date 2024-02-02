namespace LoggingSampleService;

[ServiceContract]
public interface IService
{
    [OperationContract]
    string GetData(int value);
}

[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
public class Service : IService
{
    private ILogger<Service> _logger;

    // Parameterized constructor will be called by Dependency Injection
    // Logs will be created under the name "LoggingSampleService.Service" as that's the type name used constructing the logger object
    public Service(ILogger<Service> logger)
    {
        _logger = logger;
    }


    public string GetData(int value)
    {
        _logger.LogInformation("GetData called with value {value}", value);
        return string.Format("You entered: {0}", value);
    }
}