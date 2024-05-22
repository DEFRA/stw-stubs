namespace STW.StubApi.Presentation.Services.Notification.Helpers;

public static class NotificationHelper
{
    public static string GenerateReferenceNumber(string certificateType)
    {
        var currentYear = DateTime.Now.Year;
        var rand = new Random();
        var random = "1" + rand.Next(0, 1000000).ToString("D6");

        return $"{certificateType}.GB.{currentYear}.{random}";
    }
}
