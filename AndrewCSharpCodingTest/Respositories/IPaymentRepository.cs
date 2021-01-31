using AndrewCSharpCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Respositories
{
    public interface IPaymentRepository
    {
        public Task AddPayment(Payment payment,bool status);
    }
}
