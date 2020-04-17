using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibRest.Core;
using FibRest.Models;

namespace FibRest.Services
{
    public class FibDbService: IFibDbService
    {
        private readonly AppDbContext _db;

        private readonly IFibCalcService _fibCalcService;

        public FibDbService(AppDbContext db, IFibCalcService fibCalcService)
        {
            _db = db;
            _fibCalcService = fibCalcService;
        }

        public async Task CalculateAsync(FibRequest model)
        {
            var result = _fibCalcService.Calculate(model.NumberToCalculate);
            await _db.FibResults.AddAsync(new FibResult
            {
                Result = result,
                ElementNumber = model.NumberToCalculate
            });

            await _db.SaveChangesAsync();
        }

        public IEnumerable<FibResultResponse> GetAll()
        {
            return _db.FibResults.Select(r => new FibResultResponse
            {
                Id = r.Id,
                ElementNumber = r.ElementNumber,
                Result = r.Result
            });
        }

        private int Fib(int x)
        {
            if (x < 2)
                return x;

            return Fib(x - 2) + Fib(x - 1);
        }


    }
}
