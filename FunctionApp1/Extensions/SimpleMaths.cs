using FunctionApp1.Models;
using FunctionApp1.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FunctionApp1.Extensions
{
    static class SimpleMathsExtension
    {

        public static int ResolveEquation(this Equation equation)
        {
            int a = equation.A;
            int b = equation.B;
            string operation = equation.Operation.ToLower();
            return Statics.mathDelegates[operation].Invoke(a, b);
        }

        public static string ResolveEquationAsString(this Equation equation)
        {
            string answer = equation.ResolveEquation().ToString();
            return $"{equation.A} {equation.Operation} {equation.B} = {answer}";
        }
    }
}
