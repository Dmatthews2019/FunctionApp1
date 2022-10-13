using Microsoft.AspNetCore.Http;
using System;

namespace FunctionApp1.Extensions
{
    public static class ValidationExtension
    {
        //reusable extension method which accepts a predicate function for dynamic validation
        //syntax note :: Func<type, type> defines a delegate where the first type is the input parameter and the second type is the output
        //               we can have syntax that covers multiple input ie Func<type, type, type> in each case the output is allways the last type
        public static bool DelegateValidation(this string requestbody, Func<string, bool> validationDelagate) {
            return validationDelagate(requestbody);
        }
    }
}
