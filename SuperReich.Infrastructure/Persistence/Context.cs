using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Bookings;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Domain.Entities.PaymentMethods;
using SuperReich.Domain.Entities.Products;
using SuperReich.Domain.Entities.Roles;
using SuperReich.Domain.Entities.RoomCategories;
using SuperReich.Domain.Entities.RoomPrices;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Infrastructure.Persistence
{
    public class Context : DbContext
    {
        private readonly IDateTimeChile _dateTimeChile;
        private readonly ICurrentUserRepository _currentUserRepository;
        public Context(DbContextOptions<Context> options, IDateTimeChile dateTime, ICurrentUserRepository currentUserRepository) : base(options)
        {
            _dateTimeChile = dateTime;
            _currentUserRepository = currentUserRepository;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Audit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeChile.GetCurrentChileTime();
                        entry.Entity.CreatedBy = _currentUserRepository.Username ?? "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTimeChile.GetCurrentChileTime();
                        entry.Entity.LastModifiedBy = _currentUserRepository.Username ?? "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryPrice> CategoryPrices { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
