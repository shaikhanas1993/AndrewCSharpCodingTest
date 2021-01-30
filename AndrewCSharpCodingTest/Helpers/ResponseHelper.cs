using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace AndrewCSharpCodingTest.Helpers
{
    public static class ResponseHelper
    {
        public static ResponseModel GenerateResponse(int code, bool status, string message, Object response)
        {

            return new ResponseModel
            {
                code = code,
                status = status,
                message = message,
                response = response
            };
        }

        public static IActionResult Response(int code, bool status, string message, Object response)
        {
            return new ObjectResult(GenerateResponse(code, status, message, response));

        }

    }
}
