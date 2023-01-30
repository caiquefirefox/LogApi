namespace Log.Domain.AggregateModel.User;

public class Credential
{
    public List<User> Users { get; private set; }

    public Credential()
    {
        Users = new List<User>();
    }

    public void AddUser(string username, string password)
    {
        Random random = new Random();
        Users.Add(new User(random.Next(1,100), username, password));
    }
}
