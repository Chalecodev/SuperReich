using Microsoft.EntityFrameworkCore;
using SuperReich.Domain.Entities.Clients;
using SuperReich.Domain.Entities.Roles;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Infrastructure.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().Ignore(u => u.Rut);  // Ignorar la propiedad Rut

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Client> Clients { get; set; }
    }
}
