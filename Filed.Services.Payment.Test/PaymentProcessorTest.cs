using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Filed.Services.Payment.DAL;
using Filed.Services.Payment.DAL.Database;
using Filed.Services.Payment.PaymentGateway;
using Filed.Services.Payment.Models;

namespace Filed.Services.Payment.Test
{
    [TestClass]
    public class PaymentProcessorTest : BaseTest
    {
        [TestMethod]
        public void TestCheap()
        {
            try
            {
                PaymentProcessor processor = this.GetService<PaymentProcessor>();
                processor.ProcessPayment(new PaymentModel()
                {
                    Amount = 10,
                    CardHolder = "Some Card Holder",
                    CreditCardNumber = "4111111111111111",
                    ExpirationDate = DateTime.Now.AddDays(35),
                    SecurityCode = "123"
                });

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestExpensive()
        {
            try
            {
                PaymentProcessor processor = this.GetService<PaymentProcessor>();
                bool result = processor.ProcessPayment(new PaymentModel()
                {
                    Amount = 40,
                    CardHolder = "Some Card Holder",
                    CreditCardNumber = "4111111111111111",
                    ExpirationDate = DateTime.Now.AddDays(35),
                    SecurityCode = "123"
                });

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestPremium()
        {
            try
            {
                PaymentProcessor processor = this.GetService<PaymentProcessor>();
                bool result = processor.ProcessPayment(new PaymentModel()
                {
                    Amount = 5025,
                    CardHolder = "Some Card Holder",
                    CreditCardNumber = "4111111111111111",
                    ExpirationDate = DateTime.Now.AddDays(35),
                    SecurityCode = "123"
                });

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
