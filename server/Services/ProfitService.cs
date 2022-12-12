using server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace server.Services;

public class ProfitService: IBarService<Profit>
{
    public IMongoCollection<Profit>_mongoCollection { get; set ; }

    public ProfitService(
        IOptions<BarDatabaseSettings> barDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            barDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            barDatabaseSettings.Value.DatabaseName);

        _mongoCollection = mongoDatabase.GetCollection<Profit>(
            barDatabaseSettings.Value.ProfitCollectionName);
    }

    public async Task<List<Profit>> GetAsync() =>
        await _mongoCollection.Find(_ => true).ToListAsync();

    public async Task<Profit?> GetAsync(string id) =>
        await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Profit newProfit) =>
        await _mongoCollection.InsertOneAsync(newProfit);

    public async Task UpdateAsync(string id, Profit updatedProfit) =>
        await _mongoCollection.ReplaceOneAsync(x => x.Id == id, updatedProfit);

    public async Task RemoveAsync(string id) =>
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
}