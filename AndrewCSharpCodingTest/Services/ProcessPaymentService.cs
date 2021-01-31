using AndrewCSharpCodingTest.GatewayClients;
using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
using AndrewCSharpCodingTest.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Services
{
    public class ProcessPaymentService : IProccessPaymentService
    {
        private readonly ICheapGatewayService _cheapGatewayServie;
        private readonly IPaymentRepository _paymentRepository;
        public ProcessPaymentService(ICheapGatewayService cheapGatewayService, IPaymentRepository paymentRepository)
        {
            _cheapGatewayServie = cheapGatewayService;
            _paymentRepository = paymentRepository;
        }

        public Task<FakeGatewayResponse> processPayment(Payment payment)
        {
            //throw new NotImplementedException();
            if(payment.Amount <= 20)
            {
                return useCheapGatewayPaymentProvider(payment);
            }else if(payment.Amount > 20 && payment.Amount <= 500)
            {
                throw new Exception("Something Wrong with the payment amount.");
            }
            else if (payment.Amount >  500)
            {
                return usePremiumPaymentGatewayProvider(payment);
            }
            else
            {
                throw new Exception("Something Wrong with the payment amount.");
            }
        }

        private Task<FakeGatewayResponse> usePremiumPaymentGatewayProvider(Payment payment)
        {
            throw new NotImplementedException();
        }

        private async Task<FakeGatewayResponse> useCheapGatewayPaymentProvider(Payment payment)
        {
            //throw new NotImplementedException();
            bool isServerAvailable = await _cheapGatewayServie.isServerAvailable();
            if(!isServerAvailable)
            {
                await _paymentRepository.AddPayment(payment, false);
                return new FakeGatewayResponse
                {
                    code = HelperVariables.SERVER_UNAVAILABLE,
                    status = false,
                    message = HelperVariables.CLIENT_SERVER_UNAVAILABLE
                };
            }
           
            var response  = await _cheapGatewayServie.hitEternalApiGateywayService();
            await _paymentRepository.AddPayment(payment, response.status);
            return response;
        }
    }
}
