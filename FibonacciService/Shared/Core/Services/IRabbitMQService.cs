using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Services
{
    public interface IRabbitMqService
    {
        void Send(FibRequest model);

        FibRequest Fetch();
    }
}
