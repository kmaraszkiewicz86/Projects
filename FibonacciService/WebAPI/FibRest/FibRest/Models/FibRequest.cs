using System;
using System.ComponentModel.DataAnnotations;

namespace FibRest.Models
{
    public class FibRequest
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int NumberToCalculate { get; set; }
    }
}
