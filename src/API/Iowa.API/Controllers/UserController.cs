using Iowa.API.Controllers.Base;
using Iowa.Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class UserController : IowaController {

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
        return Ok(Array.Empty<string>());
    }
}
