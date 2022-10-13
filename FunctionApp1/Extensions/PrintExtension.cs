using Microsoft.AspNetCore.Http;
using System;

namespace FunctionApp1.Extensions
{
    public static class PrintExtension
    {
        public static void PrintToConsole(this HttpRequest request)
        {
            Console.WriteLine($"Request to {request.Path} At time {DateTime.Now}");
            Console.WriteLine($"=============================================");
            Console.WriteLine($" ");
            foreach (var item in request.Query)
            {
                Console.WriteLine($"{item.Key} :: {item.Value}");
            }
            Console.WriteLine($" ");
            Console.WriteLine($"=============================================");
        }
    }
}
