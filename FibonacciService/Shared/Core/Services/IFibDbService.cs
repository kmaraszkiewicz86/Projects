using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IFibDbService
    {
        Task<FibResultResponse> CalculateAsync(FibRequest model);

        IEnumerable<FibResultResponse> GetAll();
    }
}
