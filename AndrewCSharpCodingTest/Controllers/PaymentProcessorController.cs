using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Models;
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

        public PaymentProcessorController(ILogger<PaymentProcessorController> logger) {
            _logger = logger;
        }

        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
                await Task.Run(() => Console.WriteLine("h"));
                return ResponseHelper.Response(HelperVariables.OK, HelperVariables.SUCCESS_STATUS, HelperVariables.SUCCESS_MESSAGE, null);
        }
    }
}
