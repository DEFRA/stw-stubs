namespace STW.StubApi.Presentation.Services.Notification.Validators;

using System.Text.Json.Nodes;
using Json.Schema;

public class NotificationValidator : INotificationValidator
{
    private const string SchemaPath = "Services/Notification/Schemas/notification.json";
    private static readonly JsonSchema Schema = JsonSchema.FromFile(SchemaPath);

    public bool IsValid(JsonNode? notification)
    {
        var result = Schema.Evaluate(notification);

        return result.IsValid;
    }
}
