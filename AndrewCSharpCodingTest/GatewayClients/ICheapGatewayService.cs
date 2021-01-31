using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.GatewayClients
{
    public interface ICheapGatewayService : IFakeServerSimulation
    {
        Task<bool> isServerAvailable();
    }
}
