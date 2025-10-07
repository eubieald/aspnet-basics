using Microsoft.EntityFrameworkCore;
using ProjectApiBasics.Data;

namespace ProjectApiBasics.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        public DbSet<Application> Games { get; set; }
    }
}
