using Microsoft.EntityFrameworkCore;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.ValueObjects;

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
        if (!await context.Users.AnyAsync())
        {
            //DateTime.Parse("09-11-2001")
            //_dateTimeChile.GetSpecificChileTime(new DateTime(2001, 11, 09)), // YYYY/MM/DD
            await context.Users.AddAsync(new User()
            {
                //Id = 1,
                Rut = new RUT("20889157-K").Value,
                Names = "xxxxx xxxxx",
                Surnames = "xxxxx xxxxx",
                Email = "xxxxx.xxxxx@xxx.com",
                Password = "1234",
                Birthdate = DateTime.Parse("09-11-2001"),
                Address = "xxxxxxxxxxxxxxx",
                PhoneNumber = "+xxxxxxxxxx",
                CreatedBy = "Chaleco",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Chaleco",
                LastModifiedDate = null,
                IsDeleted = false,
            });
        }

        await context.SaveChangesAsync();
    }
}