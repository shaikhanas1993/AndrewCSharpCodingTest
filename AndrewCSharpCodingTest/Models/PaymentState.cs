using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Models
{
        

    public class PaymentState
    {
        public enum PaymentStatus
        {
            pending,
            processed,
            failed
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentStateId { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }

        public Payment Payment { get; set; }
    }
}
