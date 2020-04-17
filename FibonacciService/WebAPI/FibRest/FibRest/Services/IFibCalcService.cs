using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibRest.Services
{
    public interface IFibCalcService
    {
        long Calculate(int x);
    }
}
