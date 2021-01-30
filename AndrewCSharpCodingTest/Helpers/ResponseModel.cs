using System;
namespace AndrewCSharpCodingTest.Helpers
{
    public class ResponseModel
    {
        public int code { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public Object response { get; set; }

    }
}
