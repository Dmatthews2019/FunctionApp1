using FunctionApp1.Extensions;
using FunctionApp1.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.Models
{
    public class Equation
    {
        [Required]
        public int A { get; set; }
        [Required]
        public int B { get; set; }
        [Required]
        public string Operation { get; set; }

    }
}
