using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill
{
    public class AppDbContext : DbContext
    {
        //two constructors, one parameterless and another one with dbcontext options
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}
