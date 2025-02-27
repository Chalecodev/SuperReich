using Microsoft.EntityFrameworkCore;
using SuperReich.Domain.Entities.Bookings;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Domain.Entities.PaymentMethods;
using SuperReich.Domain.Entities.Roles;
using SuperReich.Domain.Entities.RoomCategories;
using SuperReich.Domain.Entities.RoomPrices;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;
using static SuperReich.Application.Helper.Encryptor;

namespace SuperReich.Infrastructure.Persistence;

public class DbInitializer
{
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
            await context.Users.AddAsync(new User()
            {
                Rut = new RUT("20889157-K").Value,
                Passport = "xxxxx",
                Names = "Israel Cabrera",
                Surnames = "xxxxx xxxxx",
                Email = "chaleco@gmail.com",
                Password = EncryptPassword("1234"),
                Birthdate = DateTime.Parse("09-11-2001"),
                Address = "xxxxxxxxxxxxxxx",
                PhoneNumber = "+xxxxxxxxxx",
                RoleId = 1
            });
        }

        if (!await context.CategoryPrices.AnyAsync())
        {
            //Base, Descuento, Promoción, Alta Demanda
            await context.CategoryPrices.AddAsync(new CategoryPrice()
            {
                Price = 20000,
                PriceType = "Base",
                Season = "Verano"
            });
        }

        if (!await context.RoomCategories.AnyAsync())
        {
            await context.RoomCategories.AddAsync(new RoomCategory()
            {
                Description = "Matrimonial",
                CategoryPriceId = 1,
                CreatedBy = "Chaleco"
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
                Status = "Disponible"
            });
        }

        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddAsync(new Customer()
            {
                Rut = new RUT("20889157-K").Value,
                Passport = "",
                Names = "xxxxx xxxxx",
                Surnames = "xxxxx xxxxx",
                Email = "",
                Nationality = "Chilena",
                PhoneNumber = "+xxxxxxxxxx",
                Birthdate = DateTime.Parse("09-11-2001"),
                Address = "xxxxxxxxxxxxxxx",
                Note = "xxxxxxxxxxxxxxx",
                BlackList = false
            });

            await context.SaveChangesAsync();
        }


        if (!await context.PaymentMethods.AnyAsync())
        {
            await context.PaymentMethods.AddAsync(new PaymentMethod()
            {
                PaymentMethodName = "Efectivo"
            });

            await context.SaveChangesAsync();
        }

        if (!await context.Bookings.AnyAsync())
        {
            await context.Bookings.AddAsync(new Booking()
            {
                Notes = "XXXXXXXXXXXXXXXX",
                CustomerId = 1,
                PaymentMethodId = 1,
                RoomId = 1
            });
        }

        await context.SaveChangesAsync();
    }
}