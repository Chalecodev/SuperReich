using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Clients;
using SuperReich.Domain.Entities.Roles;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Infrastructure.Persistence
{
    public class Context : DbContext
    {
        private readonly IDateTimeChile _dateTimeChile;
        public Context(DbContextOptions<Context> options, IDateTimeChile dateTime) : base(options) 
        {
            _dateTimeChile = dateTime;
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().Ignore(u => u.Rut);  // Ignorar la propiedad Rut

        //    base.OnModelCreating(modelBuilder);
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Audit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeChile.GetCurrentChileTime();
                        //entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTimeChile.GetCurrentChileTime();
                        //entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<RoomPrice> RoomPrices{ get; set; }
        public DbSet<Room> Rooms{ get; set; }
    }
}
