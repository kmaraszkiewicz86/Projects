using System;
using System.ComponentModel.DataAnnotations;

namespace FibRest.Models
{
    public class FibRequest
    {
        [Required]
        [Range(2, 100)]
        public int NumberToCalculate { get; set; }
    }
}
