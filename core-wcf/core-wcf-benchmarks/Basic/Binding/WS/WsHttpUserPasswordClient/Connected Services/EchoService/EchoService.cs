﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EchoMessage", Namespace="http://schemas.datacontract.org/2004/07/WsHttpUserPasswordServer")]
    public partial class EchoMessage : object
    {
        
        private string TextField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this.TextField;
            }
            set
            {
                this.TextField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EchoFault", Namespace="http://schemas.datacontract.org/2004/07/WsHttpUserPasswordServer")]
    public partial class EchoFault : object
    {
        
        private string TextField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this.TextField;
            }
            set
            {
                this.TextField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IEchoService")]
    public interface IEchoService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoService/Echo", ReplyAction="http://tempuri.org/IEchoService/EchoResponse")]
        System.Threading.Tasks.Task<string> EchoAsync(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoService/ComplexEcho", ReplyAction="http://tempuri.org/IEchoService/ComplexEchoResponse")]
        System.Threading.Tasks.Task<string> ComplexEchoAsync(ServiceReference1.EchoMessage text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoService/FailEcho", ReplyAction="http://tempuri.org/IEchoService/FailEchoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference1.EchoFault), Action="http://tempuri.org/IEchoService/FailEchoEchoFaultFault", Name="EchoFault", Namespace="http://schemas.datacontract.org/2004/07/WsHttpUserPasswordServer")]
        System.Threading.Tasks.Task<string> FailEchoAsync(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoService/EchoForPermission", ReplyAction="http://tempuri.org/IEchoService/EchoForPermissionResponse")]
        System.Threading.Tasks.Task<string> EchoForPermissionAsync(string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IEchoServiceChannel : ServiceReference1.IEchoService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class EchoServiceClient : System.ServiceModel.ClientBase<ServiceReference1.IEchoService>, ServiceReference1.IEchoService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public EchoServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(EchoServiceClient.GetBindingForEndpoint(endpointConfiguration), EchoServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EchoServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(EchoServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EchoServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(EchoServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EchoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> EchoAsync(string text)
        {
            return base.Channel.EchoAsync(text);
        }
        
        public System.Threading.Tasks.Task<string> ComplexEchoAsync(ServiceReference1.EchoMessage text)
        {
            return base.Channel.ComplexEchoAsync(text);
        }
        
        public System.Threading.Tasks.Task<string> FailEchoAsync(string text)
        {
            return base.Channel.FailEchoAsync(text);
        }
        
        public System.Threading.Tasks.Task<string> EchoForPermissionAsync(string text)
        {
            return base.Channel.EchoForPermissionAsync(text);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IEchoService))
            {
                System.ServiceModel.WSHttpBinding result = new System.ServiceModel.WSHttpBinding();
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.SecurityMode.None;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IEchoService1))
            {
                System.ServiceModel.WSHttpBinding result = new System.ServiceModel.WSHttpBinding();
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.SecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.AuthenticatedEP))
            {
                System.ServiceModel.WSHttpBinding result = new System.ServiceModel.WSHttpBinding();
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.SecurityMode.TransportWithMessageCredential;
                result.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.None;
                result.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.UserName;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IEchoService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8088/EchoService/wsHttp");
            }
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IEchoService1))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:8443/EchoService/wsHttp");
            }
            if ((endpointConfiguration == EndpointConfiguration.AuthenticatedEP))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:8443/EchoService/wsHttpUserPassword");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WSHttpBinding_IEchoService,
            
            WSHttpBinding_IEchoService1,
            
            AuthenticatedEP,
        }
    }
}
