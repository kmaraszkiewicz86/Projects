using Core.Models;

namespace Core.Services
{
    public class RabbitMqService: IRabbitMqService
    {
        public void Send(FibRequest model)
        {
            
        }

        public FibRequest Fetch()
        {
            return new FibRequest
            {
                NumberToCalculate = 10
            };
        }
    }
}
