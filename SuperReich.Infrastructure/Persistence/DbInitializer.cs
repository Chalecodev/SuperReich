using Microsoft.EntityFrameworkCore;
using SuperReich.Domain.Entities.Roles;
using SuperReich.Domain.Entities.RoomCategories;
using SuperReich.Domain.Entities.RoomPrices;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;
using static SuperReich.Infrastructure.Services.Encryptor;

namespace SuperReich.Infrastructure.Persistence;

public class DbInitializer
{
    //private static IDateTimeChile _dateTimeChile;
    //public DbInitializer(IDateTimeChile dateTimeChile)
    //{
    //    _dateTimeChile = dateTimeChile;
    //}

    public static async Task Initialize(Context context)
    {
        if (true)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await Seed(context);
        }
    }

    private static async Task Seed(Context context)
    {
        if (!await context.Roles.AnyAsync())
        {
            await context.Roles.AddAsync(new Role() { Rolename = "Administrador" });
            await context.Roles.AddAsync(new Role() { Rolename = "Auxiliar" });
            await context.Roles.AddAsync(new Role() { Rolename = "Soporte" });
            await context.Roles.AddAsync(new Role() { Rolename = "Cajero" });
            await context.Roles.AddAsync(new Role() { Rolename = "Desarrollador" });
        }

        if (!await context.Users.AnyAsync())
        {
            //DateTime.Parse("09-11-2001")
            //_dateTimeChile.GetSpecificChileTime(new DateTime(2001, 11, 09)), // YYYY/MM/DD
            await context.Users.AddAsync(new User()
            {
                Rut = new RUT("20889157-K").Value,
                Names = "xxxxx xxxxx",
                Surnames = "xxxxx xxxxx",
                Email = "xxxxx.xxxxx@xxx.com",
                Password = EncryptPassword("1234"),
                Birthdate = DateTime.Parse("09-11-2001"),
                Address = "xxxxxxxxxxxxxxx",
                PhoneNumber = "+xxxxxxxxxx",
                RoleId = 1,
                CreatedBy = "Chaleco",
                CreatedDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            });
        }

        if (!await context.RoomPrices.AnyAsync())
        {
            await context.RoomPrices.AddAsync(new RoomPrice()
            {
                //Base, Descuento, Promoción, Alta Demanda
                Price = 20000,
                PriceType = "Base",
                Season = "Verano",
                CreatedBy = "Chaleco",
                CreatedDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            });
        }

        if (!await context.RoomCategories.AnyAsync())
        {
            await context.RoomCategories.AddAsync(new RoomCategory()
            {
                Description = "Matrimonial",
                CreatedBy = "Chaleco",
                RoomPriceId = 1,
                CreatedDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            });
        }

        if (!await context.Rooms.AnyAsync())
        {
            await context.Rooms.AddAsync(new Room()
            {
                Description = "XXXXXXXXXXXXXXXXXXX",
                Capacity = 4,
                NumberRoom = 1,
                RoomCategoryId = 1,
                Status = "Disponible",
                CreatedBy = "Chaleco",
                CreatedDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                IsDeleted = false
            });
        }

        await context.SaveChangesAsync();
    }
}