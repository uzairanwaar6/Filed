using Filed.Services.Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.PaymentGateway
{
    public class PaymentProcessor
    {
        private ICheapPaymentGateway CheapGateway { get; set; }
        private IExpensivePaymentGateway ExpensiveGateway { get; set; }
        public PaymentProcessor(ICheapPaymentGateway cheapGateway, IExpensivePaymentGateway expensiveGateway)
        {
            this.CheapGateway = cheapGateway;
            this.ExpensiveGateway = expensiveGateway;
        }

        public bool ProcessPayment(PaymentModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            bool succeed = false;

            if (model.Amount <= 20)
            {
                succeed = CheapGateway.ProcessCheapPayment(model.CreditCardNumber, model.Amount, model.ExpirationDate, model.SecurityCode);
            }
            else if (model.Amount >= 21 && model.Amount <= 500)
            {
                succeed = ExpensiveGateway.ProcessExpensivePayment(model.CreditCardNumber, model.Amount, model.ExpirationDate, model.SecurityCode);

                //Retry with Cheap Gateway
                if (!succeed)
                    succeed = CheapGateway.ProcessCheapPayment(model.CreditCardNumber, model.Amount, model.ExpirationDate, model.SecurityCode);
            }
            else
            {
                //Retry 3 times
                for (int i = 0; i < 3; i++)
                {
                    succeed = ExpensiveGateway.ProcessExpensivePayment(model.CreditCardNumber, model.Amount, model.ExpirationDate, model.SecurityCode);

                    //Retry if payment is not successfull
                    if (!succeed)
                        continue;

                    //Stop on successfull payment
                    break;
                }

            }


            return succeed;


        }
    }
}
