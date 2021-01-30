using CreditCardValidator;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndrewCSharpCodingTest.CustomValidators
{
    public class CreditCardNumberValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
            {
                return false;
            }
            try 
            {
                CreditCardDetector detector = new CreditCardDetector(strValue);
                return detector.IsValid() ? true : false;
               
            }catch (Exception)
            {
                return false;
            }
        }
    }
}
