using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filed.Services.Payment.DAL.Database
{
    public class tbl_Payments: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CreditCardNumber { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(10)]
        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }


        public tbl_Payment_Statuses PaymentStatus { get; set; }

    }
}
