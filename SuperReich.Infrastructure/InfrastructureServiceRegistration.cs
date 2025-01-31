using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Infrastructure.Persistence;
using SuperReich.Infrastructure.Repositories;
using SuperReich.Infrastructure.Services;

namespace SuperReich.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? con = configuration.GetConnectionString("SqlServerConection");
        services.AddDbContext<Context>(options => options.UseSqlServer(con));

        services.AddSingleton<IDateTimeChile, DateTimeChile>();
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<JwtTokenService>();

        //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        //services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}