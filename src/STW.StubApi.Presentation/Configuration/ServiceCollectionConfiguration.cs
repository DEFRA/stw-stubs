namespace STW.StubApi.Presentation.Configuration;

using Services.Notification.Validators;

public static class ServiceCollectionConfiguration
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationValidator, NotificationValidator>();

        return serviceCollection;
    }
}
