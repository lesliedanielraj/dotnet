using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BasicHttpBindingService
{
    public class BasicHttpBindingStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CoreWCF Services, with metadata (WSDL) support
            services.AddServiceModelServices()
                .AddServiceModelMetadata();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseServiceModel(builder =>
            {
                // Add the Services
                builder.AddService<SearchService>(serviceOptions => { })
                    .AddService<CalculatorService>(serviceOptions => { })
                    // Add BasicHttpBinding endpoint
                    .AddServiceEndpoint<SearchService, ISearchService>(new BasicHttpBinding(),
                        "/SearchService/basicHttp")
                .AddServiceEndpoint<CalculatorService, ICalculatorService>(new BasicHttpBinding(), "/CalculatorService/basicHttp");

                // Configure WSDL to be available
                var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
                serviceMetadataBehavior.HttpGetEnabled = true;
            });
        }
    }
}