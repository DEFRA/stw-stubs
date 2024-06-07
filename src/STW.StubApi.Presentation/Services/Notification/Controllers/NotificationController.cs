namespace STW.StubApi.Presentation.Services.Notification.Controllers;

using System.Net.Mime;
using System.Text.Json.Nodes;
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
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult CreateNotification([FromBody] JsonNode? notification)
    {
        var isValid = _notificationValidator.IsValid(notification);

        if (!isValid)
        {
            return BadRequest();
        }

        var referenceNumber = NotificationHelper.GenerateReferenceNumber(notification!["type"]!.ToString());

        return StatusCode(StatusCodes.Status201Created, referenceNumber);
    }
}
