using Iowa.API.Controllers.Base;
using Iowa.Domain.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class UserController : IowaController {

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
        return await Task.Run(() => {
            return Ok(Array.Empty<string>());
        });
    }
}
