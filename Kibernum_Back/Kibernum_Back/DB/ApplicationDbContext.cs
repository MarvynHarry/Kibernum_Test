using Kibernum_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Kibernum_Back.DB
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
