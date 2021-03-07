using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Filed.Services.Payment.DAL;
using Filed.Services.Payment.DAL.Database;

namespace Filed.Services.Payment.Test
{
    [TestClass]
    public class PaymentRepositoryTest : BaseTest
    {
        [TestMethod]
        public void Insert()
        {
            PaymentRepository repository = this.GetService<PaymentRepository>();
            tbl_Payments entity = repository.Insert(new tbl_Payments()
            {
                Amount = 2500,
                CardHolder = "Card Hoder",
                CreatedOn = DateTime.Now,
                CreditCardNumber = "XXXXXXXX1111",
                ExpirationDate = DateTime.Now.AddDays(25),
                SecurityCode = 123.ToString()
            });

            Assert.IsTrue(entity.ID > 0);
        }
    }
}
