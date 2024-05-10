namespace STW.StubApi.Presentation.Services.Notification.Controllers;

using Extensions;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Validators;

[ApiController]
[Route("notifications")]
public class NotificationController : ControllerBase
{
    private readonly INotificationValidator _notificationValidator;

    public NotificationController(INotificationValidator notificationValidator)
    {
        _notificationValidator = notificationValidator;
    }

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> CreateNotification()
    {
        var notification = await Request.Body.ReadAsStringAsync();

        var isValid = _notificationValidator.IsValid(notification);

        if (!isValid)
        {
            return BadRequest();
        }

        var referenceNumber = NotificationHelper.GenerateReferenceNumber();

        return StatusCode(StatusCodes.Status201Created, referenceNumber);
    }
}
