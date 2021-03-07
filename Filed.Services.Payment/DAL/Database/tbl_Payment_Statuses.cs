using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filed.Services.Payment.DAL.Database
{
    public class tbl_Payment_Statuses : BaseEntity
    {      

        [ForeignKey(nameof(tbl_Payments))]
        public int PaymentID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Status { get; set; }     

        public tbl_Payments Payment { get; set; }


    }
}
