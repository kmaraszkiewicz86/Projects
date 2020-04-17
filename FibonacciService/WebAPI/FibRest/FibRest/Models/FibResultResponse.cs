using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibRest.Models
{
    public class FibResultResponse
    {
        public int Id { get; set; }

        public int ElementNumber { get; set; }

        public long Result { get; set; }
    }
}
