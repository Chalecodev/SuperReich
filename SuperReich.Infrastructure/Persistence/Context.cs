using Microsoft.EntityFrameworkCore;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;

namespace SuperReich.Infrastructure.Persistence
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().Ignore(u => u.Rut);  // Ignorar la propiedad Rut

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<User> Users { get; set; }
    }
}
