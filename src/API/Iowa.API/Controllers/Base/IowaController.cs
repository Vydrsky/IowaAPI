using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers.Base;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class IowaController : ControllerBase {
}
