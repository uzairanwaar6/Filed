using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Filed.Services.Payment.DAL;
using Filed.Services.Payment.DAL.Database;

namespace Filed.Services.Payment.Test
{
    [TestClass]
    public class PaymentStatusRepositoryTest : BaseTest
    {
        [TestMethod]
        public void Insert()
        {
            PaymentStatusRepository repository = this.GetService<PaymentStatusRepository>();
            tbl_Payment_Statuses entity = repository.Insert(new tbl_Payment_Statuses()
            {
                CreatedOn = DateTime.Now,
                PaymentID = 1,
                Status = PaymentStatuses.processed.ToString()
            });

            Assert.IsTrue(entity.ID > 0);
        }

        [TestMethod]
        public void Update()
        {
            PaymentStatusRepository repository = this.GetService<PaymentStatusRepository>();
            tbl_Payment_Statuses entity = repository.Update(new tbl_Payment_Statuses()
            {
                ID = 1,
                CreatedOn = DateTime.Now,
                PaymentID = 1,
                Status = PaymentStatuses.failed.ToString()
            });

            Assert.IsTrue(entity.Status == PaymentStatuses.failed.ToString());
        }
    }
}
