using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
