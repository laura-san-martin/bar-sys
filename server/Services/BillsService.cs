using server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace server.Services;

public class BillsService:IBarService<Bills>
{
    public IMongoCollection<Bills>_mongoCollection { get; set ; }

    public BillsService(
        IOptions<BarDatabaseSettings> barDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            barDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            barDatabaseSettings.Value.DatabaseName);

        _mongoCollection = mongoDatabase.GetCollection<Bills>(
            barDatabaseSettings.Value.BillsCollectionName);
    }

    public async Task<List<Bills>> GetAsync() =>
        await _mongoCollection.Find(_ => true).ToListAsync();

    public async Task<Bills?> GetAsync(string id) =>
        await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Bills newBiil) =>
        await _mongoCollection.InsertOneAsync(newBiil);

    public async Task UpdateAsync(string id, Bills updatedBill) =>
        await _mongoCollection.ReplaceOneAsync(x => x.Id == id, updatedBill);

    public async Task RemoveAsync(string id) =>
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
}