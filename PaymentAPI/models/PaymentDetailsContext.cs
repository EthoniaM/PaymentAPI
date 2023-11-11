using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.models
{
    public class PaymentDetailsContext : DbContext
    {
        //constructor
        public PaymentDetailsContext(DbContextOptions options) : base(options)
        {
        }
        //it simple means that I need a physical table corresponding to the PaymentDetailsTable
        public DbSet<PaymentDetails> PaymentDetail { get; set; }
    }
}
