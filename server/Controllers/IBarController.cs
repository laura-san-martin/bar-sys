using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace server.Controllers;
public interface IBarController<T, U>
{
    public U _barService {get; set; }

    public async Task<List<T>> Get();

    public Task<ActionResult<T>> Get(string id);

    public Task<IActionResult> Post(T newObject);

    public Task<IActionResult> Update(string id, T updatedObject);
    public Task<IActionResult> Delete(string id);
}

