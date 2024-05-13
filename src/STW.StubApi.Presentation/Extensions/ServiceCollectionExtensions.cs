namespace STW.StubApi.Presentation.Extensions;

using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Notification.Validators;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterComponents(this IServiceCollection serviceCollection)
    {
        RegisterServices(serviceCollection);
        RegisterDatabase(serviceCollection);

        return serviceCollection;
    }

    private static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationValidator, NotificationValidator>();
    }

    private static void RegisterDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("StubApiDatabase"));
    }
}
