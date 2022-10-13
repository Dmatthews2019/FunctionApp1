using FluentValidation;
using FunctionApp1.Models;
using FunctionApp1.Predicators;
using FunctionApp1.Repository;
using System;
using System.Linq;

namespace SimpleApiCalculator.FluentValidation
{
    public class EquationValidator : AbstractValidator<Equation>
    {
        public EquationValidator()
        {
            RuleFor(e => e.A).NotEmpty();
            RuleFor(e => e.B).NotEmpty();
            RuleFor(e => e.Operation).NotEmpty();
            RuleFor(e => e.Operation).Must(Predicates.BeValidKey);
        }
    }
}
