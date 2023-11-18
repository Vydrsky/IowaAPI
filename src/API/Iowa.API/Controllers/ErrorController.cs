using Iowa.API.Controllers.Base;
using Iowa.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers; 

public class ErrorController : IowaController{

    [HttpGet("service")]
    public void ThrowServiceError() {
        throw new SampleException();
    }

    [HttpGet("unknown")]
    public void ThorwUnknnownError() {
        throw new Exception();
    }
}
