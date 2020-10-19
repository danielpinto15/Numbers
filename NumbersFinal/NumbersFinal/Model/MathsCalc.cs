using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersFinal.Model
{
    public class MathsCalc
    {
        public double Result { get; set; }

        [Required(ErrorMessage = "Please insert two numbers to calculate")]
        public string numbersToSplit { get; set; }
    }
}
