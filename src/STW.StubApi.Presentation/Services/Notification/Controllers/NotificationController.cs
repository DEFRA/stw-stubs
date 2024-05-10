namespace STW.StubApi.Presentation.Services.Notification.Controllers;

using System.Net;
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
    public async Task<IActionResult> CreateNotification()
    {
        var payload = await Request.Body.ReadAsStringAsync();

        var isValid = _notificationValidator.IsValid(payload);

        if (!isValid)
        {
            return BadRequest();
        }

        var referenceNumber = NotificationHelper.GenerateReferenceNumber();

        return StatusCode((int)HttpStatusCode.Created, referenceNumber);
    }
}
