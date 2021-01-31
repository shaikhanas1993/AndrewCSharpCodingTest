using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
using AndrewCSharpCodingTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PaymentProcessorController : ControllerBase
    {
        private readonly ILogger<PaymentProcessorController> _logger;
        private readonly IProccessPaymentService _processPaymentService;

        public PaymentProcessorController(ILogger<PaymentProcessorController> logger, IProccessPaymentService processPaymentService) {
            _logger = logger;
            _processPaymentService = processPaymentService;
        }

        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
                var response = await _processPaymentService.processPayment(payment);
                
                return ResponseHelper.Response(response.code, response.status, response.message, null);
        }
    }
}
