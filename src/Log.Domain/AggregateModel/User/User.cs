using Log.Toolkit.Data;

namespace Log.Domain.AggregateModel.User;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    public User(int id, string username, string password) : base(id) { 
        Username = username;
        Password = password;
    }
}
