using System;
using CoreWCF;

namespace BasicHttpBindingService;

[ServiceContract]
public interface ISearchService
{
    [OperationContract]
    int FindSimple(int value);
    [OperationContract]
    int Find_Generic_128_(int[] data, int value);
    [OperationContract]
    int Find_Generic_256_(int[] data, int value);
}