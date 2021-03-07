using Filed.Services.Payment.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.DAL
{
    public class PaymentStatusRepository : Repository<tbl_Payment_Statuses>
    {
        public PaymentStatusRepository(Context context) : base(context)
        {

        }
    }
}
