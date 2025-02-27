using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Infrastructure.Persistence;
using SuperReich.Infrastructure.Repositories;

namespace SuperReich.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? con = configuration.GetConnectionString("SqlServerConection");
        services.AddDbContext<Context>(options => options.UseSqlServer(con));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        services.AddScoped<IJwtHandlerRepository, JwtHandlerRepository>();
        services.AddSingleton<IDateTimeChile, DateTimeChile>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserRepository, CurrentUserRepository>();

        return services;
    }
}