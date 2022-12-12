using server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace server.Services;

public class UserService:IBarService<User>
{
    public IMongoCollection<User>_mongoCollection { get; set ; }

    public UserService(
        IOptions<BarDatabaseSettings> barDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            barDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            barDatabaseSettings.Value.DatabaseName);

        _mongoCollection = mongoDatabase.GetCollection<User>(
            barDatabaseSettings.Value.UserCollectionName);
    }

    public async Task<List<User>> GetAsync() =>
        await _mongoCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
        await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _mongoCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _mongoCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
}