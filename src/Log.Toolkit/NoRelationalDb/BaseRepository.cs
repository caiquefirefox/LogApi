using Log.Toolkit.Data;
using Log.Toolkit.Interfaces;
using Log.Toolkit.Mapper;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Log.Toolkit.NoRelationalDb;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    static BaseRepository()
    {
        BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
            cm.MapIdMember(c => c.Id);
        });
    }

    public BaseRepository()
    {
        var client = new MongoClient(MongoEnvironment.StringConnection);
        var database = client.GetDatabase(MongoEnvironment.DataBaseName);
        Objects = database.GetCollection<TEntity>(CollectionName);
    }

    protected readonly IMongoCollection<TEntity> Objects;
    protected abstract string CollectionName { get; }

    public async Task<long> CountAsync()
    {
        return await Objects.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
    }

    public async Task<TEntity> AddAsync(TEntity entity, bool applySave = true)
    {
        await Objects.InsertOneAsync(entity);
        return await GetObjectByIDAsync(entity.Id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, bool applySave = true)
    {
        TEntity t = await GetObjectByIDAsync(entity.Id);
        if (t == null)
            return null;
        var mapper = MapperFactory.Map<TEntity, TEntity>();
        t = mapper.Map<TEntity, TEntity>(entity);
        var updateResult = await Objects.ReplaceOneAsync(
            o => o.Id == t.Id, replacement: entity);
        if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            return await GetObjectByIDAsync(entity.Id);
        return null;
    }

    public async Task<bool> DeleteAsync(int id, bool applySave = true)
    {
        var deleteResult = await Objects.DeleteOneAsync(o => o.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<TEntity> GetObjectByIDAsync(int id)
    {
        var builder = Builders<TEntity>.Filter;
        var filter = builder.Eq("ID", id);
        return await Objects.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(int limit, int start)
    {
        return await Objects.Find(FilterDefinition<TEntity>.Empty)
            .Skip(start)
            .Limit(limit).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        await Task.CompletedTask;
        return false;
    }
}