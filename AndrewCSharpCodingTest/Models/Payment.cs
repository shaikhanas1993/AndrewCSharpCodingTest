using AndrewCSharpCodingTest.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;


namespace AndrewCSharpCodingTest.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }

        [Required]
        [CreditCardNumberValidator]
        public string CreditCardName { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ExpirationDateValidator]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public Double Amount { get; set; }

        public string SecurityCode { get; set; }

    }
}
