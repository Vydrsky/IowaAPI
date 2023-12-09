using Iowa.API.Controllers.Base;
using Iowa.Application.Common.Exceptions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers.NotDocumented;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : IowaController
{
    [AllowAnonymous]
    [HttpGet("service")]
    public async Task ThrowServiceError()
    {
        await Task.Run(() => throw new SampleException());
    }

    [AllowAnonymous]
    [HttpGet("unknown")]
    public async Task ThrowUnknownError()
    {
        await Task.Run(() => throw new Exception());
    }
}
