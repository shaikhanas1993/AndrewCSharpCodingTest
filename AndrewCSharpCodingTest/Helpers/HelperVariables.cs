using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Helpers
{
    public static class HelperVariables
    {
        public static readonly int UNAUTHORIZED = 401;
        public static readonly int BAD_REQUEST = 400;
        public static readonly int NOT_FOUND = 404;
        public static readonly int OK = 200;
        public static readonly int CREATED = 201;
        public static readonly int NO_CONTENT = 204;

        public static readonly int INTERNAL_SERVER_ERROR = 500;

        public static readonly int OPERATION_FAILED_CODE = 422;
        public static readonly bool FAILED_STATUS = false;
        public static readonly bool SUCCESS_STATUS = true;
        public static readonly string SUCCESS_MESSAGE = "Request was successfull";
        public static readonly string INVALID_REQUEST_MESSAGE = "Your payload is invalid.Please provide the correct payload.";
    }
}
