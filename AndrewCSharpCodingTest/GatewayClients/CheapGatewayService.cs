using AndrewCSharpCodingTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.GatewayClients
{
    public class CheapGatewayService : ICheapGatewayService
    {
        public Task<FakeGatewayResponse> hitEternalApiGateywayService()
        {
            return  Task.Delay(1000).ContinueWith(t => generateRandomResponse());
           
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

        public Task<bool> isServerAvailable()
        {
            //dummy simulation logic to generate random true or false
            return Task.Run(() => new Random().Next(0, 2) > 0);
        }
    }
}
