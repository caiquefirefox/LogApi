using Log.Domain.AggregateModel.User;
using Log.Toolkit.Web;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Log.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ManagedController
{
    private static readonly Credential _Credential = new();
    private readonly ILogger _Logger;

    public UserController(ILogger<UserController> logger) {
        _Logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(User user)
    {
        return await TryExecuteOK(async () => await AddUser(user));
    }

    private async Task<User> AddUser(User user)
    {
        Serilog.Log.Information("Usuário inserido {user} em {DT}", JsonSerializer.Serialize(user), DateTime.Now.ToString("dd/MM/yyyy"));
        _Logger.LogInformation("Usuário inserido {user} em {DT}", JsonSerializer.Serialize(user), DateTime.Now.ToString("dd/MM/yyyy"));
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

    private async Task<List<User>> GetUsers()
    {
        Serilog.Log.Information("Usuários consultados em {DT}", DateTime.Now.ToString("dd/MM/yyyy"));
        _Logger.LogInformation("Usuários consultados em {DT}", DateTime.Now.ToString("dd/MM/yyyy"));
        return _Credential.Users;
    }
}
