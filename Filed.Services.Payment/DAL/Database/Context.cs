using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.DAL.Database
{
    public class Context : DbContext
    {

        public DbSet<tbl_Payments> Payments { get; set; }
        public DbSet<tbl_Payment_Statuses> PaymentStatuses { get; set; }
        public Context(IConfiguration configuration)
        {
            Configuration = configuration.GetSection(ENDatabase.Database.ToString());
        }

        public IConfiguration Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source={Configuration[ENDatabase.Server.ToString()]};" +
                $"Initial Catalog={Configuration[ENDatabase.Name.ToString()]};" +
                $"User ID={Configuration[ENDatabase.User.ToString()]};" +
                $"Password={Configuration[ENDatabase.Password.ToString()]}");
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        #endregion

    }
}
