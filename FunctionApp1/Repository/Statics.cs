using System;
using System.Collections.Generic;

namespace FunctionApp1.Repository
{
    public static class Statics
    {
        public static string[] DEFINEDKEYS = new string[] { "a", "b", "operation" };

        public static Dictionary<string, Func<int, int, int>> mathDelegates = new Dictionary<string, Func<int, int, int>>() {
            { "add", (a,b) => a + b },
            { "subtract", (a,b) => a - b },
            { "multiply", (a,b) => a * b },
            { "divide", (a,b) => a / b },
            { "mod", (a,b) => a % b },
        };

        public static string HelpFilePath = @"C:\Users\matth\source\repos\FunctionApp1\FunctionApp1\Help.txt";

    }
}
