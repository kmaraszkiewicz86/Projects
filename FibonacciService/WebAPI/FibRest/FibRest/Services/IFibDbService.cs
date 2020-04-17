using System.Collections.Generic;
using System.Threading.Tasks;
using FibRest.Models;

namespace FibRest.Services
{
    public interface IFibDbService
    {
        Task CalculateAsync(FibRequest model);

        IEnumerable<FibResultResponse> GetAll();
    }
}
