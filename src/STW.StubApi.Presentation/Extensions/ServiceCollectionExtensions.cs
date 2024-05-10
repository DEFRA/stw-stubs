namespace STW.StubApi.Presentation.Extensions;

using Services.Notification.Validators;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterComponents(this IServiceCollection serviceCollection)
    {
        RegisterServices(serviceCollection);

        return serviceCollection;
    }

    private static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationValidator, NotificationValidator>();
    }
}
