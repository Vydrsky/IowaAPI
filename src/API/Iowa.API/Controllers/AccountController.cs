using Iowa.API.Controllers.Base;
using Iowa.Contracts.Account.Responses;

using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class AccountController : IowaController
{
    /// <summary>
    /// Returns an account by its id, if the account does not exist a new one is returned
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<AccountResponse>> GetAccount([FromRoute] Guid id) {
        return await Task.Run(Ok);
    }
}
