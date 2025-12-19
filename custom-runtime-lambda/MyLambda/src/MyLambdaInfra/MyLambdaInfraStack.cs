using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace MyLambdaInfra
{
    public class MyLambdaInfraStack : Stack
    {
        internal MyLambdaInfraStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var function = new Function(this, "MyLambdaFunction", new FunctionProps
            {
                Runtime = Runtime.PROVIDED_AL2023,
                Architecture = Architecture.X86_64,
                MemorySize = 256,
                Timeout = Duration.Seconds(30),
                Handler = "MyLambda::MyLambda.Function::FunctionHandler",
                Code = Code.FromAsset("../MyLambda/output.zip")
            });
        }
    }
}
