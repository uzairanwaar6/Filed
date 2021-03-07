using AutoMapper;
using Filed.Services.Payment.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentModel,tbl_Payments>();
        }
    }
}
