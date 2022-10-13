using System;
using FunctionApp1.Extensions;
using FluentValidation.Results;
using FluentValidation;
using FunctionApp1.Repository;

namespace FunctionApp1.Predicators
{
    public static class Predicates
    {
        //Takes in Type so function is reusable for other object types
        public static bool StringIsParsableTo<T>(this string request)
        {
            try
            {
                T convertedObject = request.ParseJsonToObject<T>();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Takes in a Type <T> to parse request into given object object
        //Takes in a Type <T2> So we are able to give a FluentValidation rule of our choice
        //Type T2 must constrained to a child of AbstractValidator<T>
        public static bool MeetsFluentRules<T,T2>(this string request)  where T2 : AbstractValidator<T>, new()
        {
            T2 validator = new T2();
            T convertedObject = request.ParseJsonToObject<T>();
            ValidationResult validationResult = validator.Validate(convertedObject);
            return validationResult.IsValid;
        }

        //Takes in a Type <T> to check if the body of the request is parsable to an object of our choice
        //Takes in a Type <T2> So we are able to give a FluentValidation rule of our choice
        //Type T2 must constrained to a child of AbstractValidator<T>
        public static bool RequestBodyIsValid<T, T2>(this string requestBody) where T2 : AbstractValidator<T>, new()
        {
            bool isValid = requestBody.DelegateValidation(StringIsParsableTo<T>) &&
                requestBody.DelegateValidation(MeetsFluentRules<T, T2>);
            return isValid;
        }

        public static bool BeValidKey(string operation)
        {
            return Statics.mathDelegates.ContainsKey(operation.ToLower());
        }
    }
}
