namespace STW.StubApi.Presentation.Services.Notification.Validators;

using System.Text.Json.Nodes;
using Json.Schema;

public class NotificationValidator : INotificationValidator
{
    private const string SchemaPath = "Services/Notification/Schemas/notification.json";
    private static readonly JsonSchema Schema = JsonSchema.FromFile(SchemaPath);
    private readonly ILogger<NotificationValidator> _logger;

    public NotificationValidator(ILogger<NotificationValidator> logger)
    {
        _logger = logger;
    }

    public bool IsValid(string notification)
    {
        try
        {
            var json = JsonNode.Parse(notification);
            var result = Schema.Evaluate(json);

            return result.IsValid;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Notification string does not contain valid JSON.");
            return false;
        }
    }
}
