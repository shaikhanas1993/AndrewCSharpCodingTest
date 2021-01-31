using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.GatewayClients
{
    public class ExpensivePaymentGateway : IExpensiveGatewayService
    {
        public Task<FakeGatewayResponse> hitEternalApiGateywayService()
        {
            //fakse Simulation
            return Task.Delay(1000).ContinueWith(t => generateRandomResponse());
        }

        private FakeGatewayResponse generateRandomResponse()
        {
            var listOfFakeResponses = new List<FakeGatewayResponse> {
            new FakeGatewayResponse
            {
                code = HelperVariables.OK,
                status = true,
                message = HelperVariables.SUCCESS_MESSAGE
            },
            new FakeGatewayResponse{
                code = HelperVariables.INTERNAL_SERVER_ERROR,
                status = false,
                message = HelperVariables.CLIENT_SERVER_ERROR_MESSAGE
            }
            };

            int index = new Random().Next(listOfFakeResponses.Count);
            return listOfFakeResponses[index];
        }

        private Task<bool> isServerAvailable()
        {
            //dummy simulation logic to generate random true or false
            return Task.Run(() => new Random().Next(0, 2) > 0);
        }

        public async Task<FakeGatewayResponse> processPayment(Payment payment)
        {
            //check if server is available
            bool _isServerAvailable = await isServerAvailable();
            if(!_isServerAvailable)
            {
                return new FakeGatewayResponse
                {
                    code = HelperVariables.SERVER_UNAVAILABLE,
                    status = false,
                    message = HelperVariables.CLIENT_SERVER_UNAVAILABLE
                };
            }

            return await hitEternalApiGateywayService();
        }
    }
}
