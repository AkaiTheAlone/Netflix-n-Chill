using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill.Models.Modelos;

namespace Netflix_n_Chill.Repo
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
        public DbSet<Person> Persons { get; set; }
    }
}
