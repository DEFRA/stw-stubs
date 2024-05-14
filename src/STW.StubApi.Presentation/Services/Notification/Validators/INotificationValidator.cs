namespace STW.StubApi.Presentation.Services.Notification.Validators;

using System.Text.Json.Nodes;

public interface INotificationValidator
{
    bool IsValid(JsonNode? notification);
}
