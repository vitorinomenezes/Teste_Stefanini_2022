using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Configuration
{
    public class Context : DbContext
    {

        public Context() { }
       
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseInMemoryDatabase("StefaniniDb");
            base.OnConfiguring(options);
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pessoa>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}
