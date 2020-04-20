﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class FibRequest
    {
        [Required]
        [Range(2, 100)]
        public int NumberToCalculate { get; set; }
    }
}