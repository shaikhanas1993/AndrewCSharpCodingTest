using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Services
{
    public interface IProccessPaymentService
    {
        Task<FakeGatewayResponse> processPayment(Payment payment);
    }
}
