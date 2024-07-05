using Microsoft.EntityFrameworkCore;
using MVCEF.Models.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MVCEF.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
