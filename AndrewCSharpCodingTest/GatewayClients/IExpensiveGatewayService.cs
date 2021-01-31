using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.GatewayClients
{
    public interface IExpensiveGatewayService:IFakeServerSimulation
    {
        public Task<FakeGatewayResponse> processPayment(Payment payment);
    }
}
