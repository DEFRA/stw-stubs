namespace STW.StubApi.Presentation.Services.FieldConfig.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("configurations")]
public class FieldConfigController : ControllerBase
{
    [HttpGet("v2/{certType}-{commodityCode}")]
    public FieldConfigDto GetWithOptionalComplementName(string certType, string commodityCode)
    {
        return FieldConfigHelper.GetFieldConfigDto(certType, commodityCode);
    }
}
