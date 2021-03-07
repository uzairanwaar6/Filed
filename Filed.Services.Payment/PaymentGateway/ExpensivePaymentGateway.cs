using Filed.Services.Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.PaymentGateway
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool ProcessExpensivePayment(string ccNumber, decimal amount, DateTime expirationDate, string securityCode)
        {
            if (string.IsNullOrWhiteSpace(ccNumber))
                throw new MissingFieldException(ccNumber);

            if (!(ccNumber.Length > 15 && ccNumber.Length < 21))
                throw new InvalidArgumentException("Invalid Credit Card Number");

            if (amount < 1)
                throw new InvalidArgumentException("Invalid Amount");

            if (expirationDate.Date < DateTime.Now.Date)
                throw new InvalidArgumentException("Invalid Expiration Date");

            if (!string.IsNullOrWhiteSpace(securityCode) && securityCode.Length != 3)
                throw new InvalidArgumentException("Invalid Security Code");


            //Simulating Payment Processing
            Random random = new Random();
            if((random.Next() % 2) == 0)
            {
                //Payment is processed
                return true;
            }
            else
            {
                //Payment is not processed
                return false;
            }

        }
    }
}
