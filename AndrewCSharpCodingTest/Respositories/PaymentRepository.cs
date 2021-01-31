using AndrewCSharpCodingTest.Core;
using AndrewCSharpCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Respositories
{
    public class PaymentRepository : IPaymentRepository
    {
        DatabaseContext _databaseContext;
        public PaymentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddPayment(Payment payment, bool status)
        {
            _databaseContext.Payments.Add(payment);
            var result = await _databaseContext.SaveChangesAsync();
            if (result > 0)
            {
                //insert payment status
                PaymentState.PaymentStatus paymentStatus = PaymentState.PaymentStatus.pending;
                if (status == true)
                {
                    paymentStatus = PaymentState.PaymentStatus.processed;
                }
                else
                {
                    paymentStatus = PaymentState.PaymentStatus.failed;
                }
                PaymentState paymentState = new PaymentState { Payment = payment, paymentStatus = paymentStatus };
                _databaseContext.PaymentState.Add(paymentState);
                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
