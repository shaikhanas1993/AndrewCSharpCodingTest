using System;
using System.ComponentModel.DataAnnotations;

namespace AndrewCSharpCodingTest.CustomValidators
{
    public class ExpirationDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                if (Convert.ToDateTime(value) >= DateTime.Today)
                {
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                return false;
            }
           
        }
    }
}
