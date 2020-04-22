using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Core;
using Core.Models;

namespace Core.Services
{
    public class FibDbService: IFibDbService
    {
        private readonly AppDbContext _db;

        public FibDbService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<FibResultResponse> CalculateAsync(FibResult model)
        {
            await _db.FibResults.AddAsync(model);

            await _db.SaveChangesAsync();

            return new FibResultResponse
            {
                Id = model.Id,
                ElementNumber = model.ElementNumber,
                Result = model.Result
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
