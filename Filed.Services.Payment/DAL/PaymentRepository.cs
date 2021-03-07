using Filed.Services.Payment.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.DAL
{
    public class PaymentRepository : Repository<tbl_Payments>
    {
        public PaymentRepository(Context context) : base(context)
        {

        }
    }
}
