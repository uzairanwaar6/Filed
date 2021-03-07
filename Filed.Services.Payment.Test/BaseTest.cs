using Filed.Services.Payment.DAL;
using Filed.Services.Payment.DAL.Database;
using Filed.Services.Payment.PaymentGateway;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filed.Services.Payment.Test
{
    public class BaseTest
    {
        private ServiceProvider ServiceProvider { get; set; }
        protected BaseTest()
        {
            var services = new ServiceCollection();

            
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build());
            services.AddDbContext<Context>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<PaymentRepository>();
            services.AddScoped<PaymentStatusRepository>();
            services.AddSingleton<PaymentProcessor>();
            services.AddSingleton<ICheapPaymentGateway>(new CheapPaymentGateway());
            services.AddSingleton<IExpensivePaymentGateway>(new ExpensivePaymentGateway());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            ServiceProvider = services.BuildServiceProvider();
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
