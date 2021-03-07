using AutoMapper;
using Filed.Services.Payment.DAL;
using Filed.Services.Payment.DAL.Database;
using Filed.Services.Payment.Models;
using Filed.Services.Payment.PaymentGateway;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filed.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private PaymentProcessor Processor { get; set; }
        private PaymentRepository PaymentRepository { get; set; }
        private PaymentStatusRepository PaymentStatusRepository { get; set; }
        private IMapper Mapper { get; set; }
        public PaymentController(PaymentProcessor processor,
            PaymentRepository paymentRepository,
            PaymentStatusRepository paymentStatusRepository,
            IMapper mapper)
        {
            this.Processor = processor;
            this.PaymentStatusRepository = paymentStatusRepository;
            this.PaymentRepository = paymentRepository;
            this.Mapper = mapper;
        }


        [Route("process")]
        [HttpPost]
        public ActionResult ProcessPayment([FromBody] PaymentModel model)
        {
            try
            {
                ValidateRequest(model);

                tbl_Payments entity = Mapper.Map<tbl_Payments>(model);

                entity.CreditCardNumber = "XXXXXXXXX" + model.CreditCardNumber[(entity.CreditCardNumber.Length - 4)..];
                entity.CreatedOn = DateTime.Now;
                entity = PaymentRepository.Insert(entity);
                tbl_Payment_Statuses status = PaymentStatusRepository.Insert(new tbl_Payment_Statuses()
                {
                    PaymentID = entity.ID,
                    Status = PaymentStatuses.pending.ToString(),
                    CreatedOn = DateTime.Now
                }); ;



                bool result = Processor.ProcessPayment(model);
                status.Status = result ? PaymentStatuses.processed.ToString() : PaymentStatuses.failed.ToString();
                PaymentStatusRepository.Update(status);


                if (!result)
                    throw new Exception("Payment could not be processed");

                return Ok(new { message = "Payment processed successfully" });
            }
            catch (MissingFieldException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        private bool ValidateRequest(PaymentModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CreditCardNumber))
                throw new RequiredFiledException(nameof(model.CreditCardNumber));


            if (string.IsNullOrWhiteSpace(model.CardHolder))
                throw new RequiredFiledException(nameof(model.CardHolder));

            if (!(model.CreditCardNumber.Length > 15 && model.CreditCardNumber.Length < 21))
                throw new InvalidRequestException("Invalid Credit Card Number");

            if (model.Amount < 1)
                throw new InvalidRequestException("Invalid Amount");

            if (model.ExpirationDate.Date < DateTime.Now.Date)
                throw new InvalidRequestException("Invalid Expiration Date");

            if (!string.IsNullOrWhiteSpace(model.SecurityCode) && model.SecurityCode.Length != 3)
                throw new InvalidRequestException("Invalid Security Code");



            return true;
        }

    }
}
