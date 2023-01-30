using Log.Domain.AggregateModel.User;
using Log.Toolkit.Web;
using Microsoft.AspNetCore.Mvc;

namespace Log.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ManagedController
{
    private static Credential _Credential = new Credential();

    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(User user)
    {
        return await TryExecuteOK(async () => await AddUser(user));
    }

    private async Task<User> AddUser(User user)
    {
        _Credential.AddUser(user.Username, user.Password);
        return user;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        return await TryExecuteOK(async () => await GetUsers());
    }

    private async Task<List<User>> GetUsers(int? limit = 10, int? start = 0)
    {
        return _Credential.Users;
    }
}
