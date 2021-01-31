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
        private readonly IExpensiveGatewayService _expensiveGatewayService;
        private readonly IPaymentRepository _paymentRepository;
        public ProcessPaymentService(ICheapGatewayService cheapGatewayService, IPaymentRepository paymentRepository, IExpensiveGatewayService expensiveGatewayService)
        {
            _cheapGatewayServie = cheapGatewayService;
            _paymentRepository = paymentRepository;
            _expensiveGatewayService = expensiveGatewayService;
        }

        public Task<FakeGatewayResponse> processPayment(Payment payment)
        {
            //throw new NotImplementedException();
            if(payment.Amount <= 20)
            {
                return useCheapGatewayPaymentProvider(payment);
            }else if(payment.Amount > 20 && payment.Amount <= 500)
            {
                return tryWithPreimiumThenWithCheap(payment);
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

        private async Task<FakeGatewayResponse> usePremiumPaymentGatewayProvider(Payment payment)
        {
            //Retry three times to see if  we get a success
           int counter = 3;
           FakeGatewayResponse fakeGatewayResponse = null;
           while(counter > 0)
           {
                fakeGatewayResponse = Task.Run(() => _expensiveGatewayService.processPayment(payment)).Result;
                if(fakeGatewayResponse.status == true)
                {
                    break;
                }
                counter = counter - 1;   
           }

           if(fakeGatewayResponse == null)
           {
                throw new Exception("Something Went Wrong in usePremiumPaymentGatewayProvider");
           }
            await _paymentRepository.AddPayment(payment, fakeGatewayResponse.status);
            return fakeGatewayResponse;
        }

        private async Task<FakeGatewayResponse> tryWithPreimiumThenWithCheap(Payment payment)
        {
            //try first with premium gatway service
            var response = await _expensiveGatewayService.processPayment(payment);
            if(response.status == true)
            {
                await _paymentRepository.AddPayment(payment, response.status);
                return response;
            }
            else
            {
                //try out with cheap
                response  = await _cheapGatewayServie.hitEternalApiGateywayService();
                await _paymentRepository.AddPayment(payment, response.status);
                return response;
            }
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
