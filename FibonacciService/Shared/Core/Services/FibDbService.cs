﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Core;
using Core.Models;

namespace Core.Services
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

        public async Task<FibResultResponse> CalculateAsync(FibRequest model)
        {
            var result = new FibResult
            {
                Result = _fibCalcService.Calculate(model.NumberToCalculate),
                ElementNumber = model.NumberToCalculate
            };

            await _db.FibResults.AddAsync(result);

            await _db.SaveChangesAsync();

            return new FibResultResponse
            {
                Id = result.Id,
                ElementNumber = result.ElementNumber,
                Result = result.Result
            };
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