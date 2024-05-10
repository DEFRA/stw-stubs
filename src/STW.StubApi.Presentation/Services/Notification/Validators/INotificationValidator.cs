namespace STW.StubApi.Presentation.Services.Notification.Validators;

public interface INotificationValidator
{
      Task<bool> IsValidAsync(string notification);
}
