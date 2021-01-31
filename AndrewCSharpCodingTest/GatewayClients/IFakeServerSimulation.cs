using AndrewCSharpCodingTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.GatewayClients
{
    public interface IFakeServerSimulation
    {
        Task<FakeGatewayResponse> hitEternalApiGateywayService();
    }
}
