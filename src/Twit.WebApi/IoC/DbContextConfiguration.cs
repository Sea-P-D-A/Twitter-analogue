using Microsoft.EntityFrameworkCore;
using Twit.DataAccess.Context;

namespace Twit.WebApi.IoC;

public static class DbContextConfiguration
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TwitDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}