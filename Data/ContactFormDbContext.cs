// Example of DbContext class
using Microsoft.EntityFrameworkCore;
using netmvc.Models;

namespace netmvc.Data  
{
    public class ContactFormDbContext : DbContext
    {
        public DbSet<ContactForm> ContactForms { get; set; }

        public ContactFormDbContext(DbContextOptions<ContactFormDbContext> options)
            : base(options)
        {
        }
    }
}
