using Microsoft.EntityFrameworkCore;
using LoanProviderService.Models;

namespace LoanProviderService.Data
{
    public class LoanProviderDbContext : DbContext
    {
        public LoanProviderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoanProvider> loanProviders { get; set; }
    }
}
