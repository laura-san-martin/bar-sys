using MongoDB.Driver;

namespace server.Models;
public interface IBarService<T>
{
    IMongoCollection<T> _mongoCollection { get; set; }
    public Task<List<T>> GetAsync();

    public Task<T?> GetAsync(string id);

    public Task CreateAsync(T newBarObject);

    public Task UpdateAsync(string id, T updatedBarObject);

    public Task RemoveAsync(string id);

}