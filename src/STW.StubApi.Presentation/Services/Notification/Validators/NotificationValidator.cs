namespace STW.StubApi.Presentation.Services.Notification.Validators;

using NJsonSchema;
using NJsonSchema.Validation;

public class NotificationValidator : INotificationValidator
{
    private const string SchemaPath = "Services/Notification/Schemas/notification.json";

    public async Task<bool> IsValidAsync(string notification)
    {
        var schema = await JsonSchema.FromFileAsync(SchemaPath);

        var result = schema.Validate(notification, new JsonSchemaValidatorSettings
        {
            PropertyStringComparer = StringComparer.InvariantCultureIgnoreCase
        });

        return result.Count == 0;
    }
}
