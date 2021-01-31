using AndrewCSharpCodingTest.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndrewCSharpCodingTest.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentId { get; set; }

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
        [Range(double.Epsilon, double.MaxValue)]
        public Double Amount { get; set; }

        public string SecurityCode { get; set; }
        
    }
}
