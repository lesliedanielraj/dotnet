﻿using CoreWCF;

namespace BasicHttpBindingService;

// Service class which implements the service contract interface.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
public class CalculatorService : ICalculatorService
{
    public double Add(double n1, double n2)
    {
            return n1 + n2;
        }

    public double Subtract(double n1, double n2)
    {
            return n1 - n2;
        }

    public double Multiply(double n1, double n2)
    {
            return n1 * n2;
        }

    public double Divide(double n1, double n2)
    {
            return n1 / n2;
        }
}