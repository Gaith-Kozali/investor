using Investor.Models;
using Investor.Models.Investor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Investor.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
           
        }
        public DbSet<InvestoreAccount> investore_account { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<Book> book { get; set; }
        public DbSet<Profit> profits { get; set; }
        public DbSet <Coupon> coupon { get; set; }
    }
}
