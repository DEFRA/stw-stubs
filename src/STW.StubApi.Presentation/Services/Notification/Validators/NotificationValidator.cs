namespace STW.StubApi.Presentation.Services.Notification.Validators;

using System.Text.Json.Nodes;
using Json.Schema;

public class NotificationValidator : INotificationValidator
{
    private const string SchemaPath = "Services/Notification/Schemas/notification.json";

    public bool IsValid(string notification)
    {
        var schema = JsonSchema.FromFile(SchemaPath);
        var json = JsonNode.Parse(notification);
        var result = schema.Evaluate(json);

        return result.IsValid;
    }
}
