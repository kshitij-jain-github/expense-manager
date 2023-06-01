using ExpenseManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager
{
    public class ExpenseDbContext : IdentityDbContext<IdentityUser>
    {
        public ExpenseDbContext()
        {
        }

        public ExpenseDbContext(DbContextOptions options):base (options) { }    
      
        public virtual DbSet<ExpenseAttributes> ExpenseReport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server = sql.bsite.net\\MSSQL2016;Database =expensemanager_;User ID=expensemanager_;Password=Jain1530@.com;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security = false;");
              
            }
        }
    }
}
