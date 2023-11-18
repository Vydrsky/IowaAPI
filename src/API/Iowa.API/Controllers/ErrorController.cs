using Iowa.API.Controllers.Base;
using Iowa.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers; 

public class ErrorController : IowaController{

    [HttpGet("service")]
    public async Task ThrowServiceError() {
        await Task.Run(() => throw new SampleException());
    }

    [HttpGet("unknown")]
    public async Task ThorwUnknnownError() {
        await Task.Run(() => throw new Exception());
    }
}
