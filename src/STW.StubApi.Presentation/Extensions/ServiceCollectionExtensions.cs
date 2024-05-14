namespace STW.StubApi.Presentation.Extensions;

using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Notification.Validators;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterComponents(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IHostEnvironment hostEnvironment)
    {
        RegisterServices(serviceCollection);
        RegisterDatabase(serviceCollection, configuration, hostEnvironment);

        return serviceCollection;
    }

    private static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationValidator, NotificationValidator>();
    }

    private static void RegisterDatabase(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment.IsDevelopment())
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("StubApiDatabase"));
        }
        else
        {
            var connectionString = configuration.GetConnectionString("StubApiDatabase");
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
