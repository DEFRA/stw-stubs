namespace STW.StubApi.Presentation.Services.Notification.Validators;

using NJsonSchema;
using NJsonSchema.Validation;

public class NotificationValidator : INotificationValidator
{
    private const string SchemaPath = "Services/Notification/Schemas/notification.json";

    public bool IsValid(string notification)
    {
        var schema = JsonSchema.FromFileAsync(SchemaPath).Result;
        var result = schema.Validate(notification, new JsonSchemaValidatorSettings
        {
            PropertyStringComparer = StringComparer.InvariantCultureIgnoreCase
        });

        return result.Count == 0;
    }
}
