using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.PaymentGateway
{
  public  interface ICheapPaymentGateway
    {
        bool ProcessCheapPayment(string ccNumber, decimal amount, DateTime expirationDate, string securityCode);

    }
}
