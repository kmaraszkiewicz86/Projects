using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IFibDbService
    {
        Task<FibResultResponse> CalculateAsync(FibResult model);

        IEnumerable<FibResultResponse> GetAll();
    }
}
