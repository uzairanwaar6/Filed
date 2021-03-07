using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.PaymentGateway
{
   public  interface IExpensivePaymentGateway
    {
        bool ProcessExpensivePayment(string ccNumber, decimal amount, DateTime expirationDate, string securityCode);
    }
}
