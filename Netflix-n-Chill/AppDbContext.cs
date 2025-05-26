using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Netflix_n_Chill.Models;
using System.Reflection.Emit;

namespace Netflix_n_Chill
{
    public class AppDbContext : DbContext
    {
        private volatile int Count;
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //determine decimal`s precision for an decimal
            //builder.Entity<Books>()
            //    .Property(b => b.Price)
            //    .HasPrecision(18, 4);

            base.OnModelCreating(builder);
            for (var i = 1; i < 500; i++)
            {
                builder.Entity<Person>().HasData(new Person
                {
                    Id = IncrementAndGet(),
                    Address = Guid.NewGuid().ToString(),
                    FirstName = Guid.NewGuid().ToString(),
                    LastName = Guid.NewGuid().ToString(),
                    Gender = "Male Or Female"
                });
            }
        }
        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref Count);
        }
    }
}
