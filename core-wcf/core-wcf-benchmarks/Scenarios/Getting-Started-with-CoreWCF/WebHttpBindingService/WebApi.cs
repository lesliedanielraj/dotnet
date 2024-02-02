// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CoreWCF;

namespace WebHttpBindingService;

[ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple)]
internal class WebApi : IWebApi
{
    public string PathEcho(string param) => param;

    public string QueryEcho(string param) => param;

    public ExampleContract BodyEcho(ExampleContract param) => param;
}