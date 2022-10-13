using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionApp1.Extensions;
using FunctionApp1.Predicators;
using System.Collections.Generic;
using FunctionApp1.Models;
using SimpleApiCalculator.FluentValidation;
using SimpleApiCalculator.Services;

namespace FunctionApp1
{
    public static class SimpleApiCalculator
    {
        private static string requestBody;
        private static bool requestIsValid;
        private static HttpRequest request;
        private readonly static Dictionary<dynamic, Func<IActionResult>> result = new Dictionary<dynamic, Func<IActionResult>>() {
            {true, GiveValidResult},
            {false, GiveInValidResult},
            {"Help", GiveHelpResult }
        };
        
        [FunctionName("SimpleApiCalculator")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            SetFeildVariables(req);
            return CalculateAndGiveAppropriateResult();
        }

        private static void SetFeildVariables(HttpRequest req)
        {
            request = req;
            requestBody = request.GetRequestBodyAsString();
            requestIsValid = requestBody.RequestBodyIsValid<Equation, EquationValidator>();
        }
        private static IActionResult CalculateAndGiveAppropriateResult()
        {
            if (request.Query.ContainsKey("Help"))
            {
                return result["Help"]();
            }
            return InvokeActionFromDictionary();
        }
        private static IActionResult GiveValidResult() 
        {
            Equation equation = requestBody.ParseJsonToObject<Equation>();
            return new OkObjectResult(equation.ResolveEquationAsString());
        }
        private static IActionResult GiveInValidResult()
        {
            return new OkObjectResult("InValid Request, try using http://localhost:7071/api/SimpleApiCalculator?help for more information");
        }
        private static IActionResult GiveHelpResult()
        {
            HelpService helpService = new HelpService();
            return new OkObjectResult(helpService.HelpResponse);
        }
        private static IActionResult InvokeActionFromDictionary() 
        {
            return result[requestIsValid]();
        }
    }



}
