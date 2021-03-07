using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.DAL.Database
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
