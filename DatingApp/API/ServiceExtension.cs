using DatingApp.Data;
using DationgAppServices.Infrastrcuture;
using DationgAppServices.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContexts(this IServiceCollection services, IConfiguration config)
        {
            try
            {
                var connStrTC = string.Empty;
                var connStrSE = string.Empty;

                // Pull the conn strings from settings; if not dev, then append the user creds from secret manager
                connStrTC = config.GetConnectionString("DatingAPP");

                services.AddDbContext<Dating_APPContext>(
                    options =>
                    {
                        options.UseSqlServer(
                            connStrTC,
                            sqlServerOptionsAction: sqlOptions =>
                            {
                                sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(2),
                            errorNumbersToAdd: null);
                            })
                        .LogTo(
                            action =>
                            {
                            }, LogLevel.Information);
                    }, ServiceLifetime.Transient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ConfigureCustomServices(this IServiceCollection services, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            // Register IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IRepostioryWrapper>(w =>
    new RepositoryWrapper(
        services.BuildServiceProvider().GetService<Dating_APPContext>()));

        }
        public static void ConfigureHttpContextAccessor(this IServiceCollection services, out IHttpContextAccessor httpContextAccessor)
        {
            // To allow DI availability of HttpContext in service and domain layers
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            httpContextAccessor = services.BuildServiceProvider().GetService<IHttpContextAccessor>();
        }
    }
}
