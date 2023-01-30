namespace Log.Toolkit.Data;

public class BaseEntity
{
    public int Id { get; private set; }

    public BaseEntity(int id)
    {
        Id = id;
    }
}
