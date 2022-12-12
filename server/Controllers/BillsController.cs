using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillsController : ControllerBase, IBarController<Bills, BillsService>
{
    public BillsService _barService { get; set; }

    public BillsController(BillsService usersService) =>
        _barService = usersService;

    [HttpGet]
    public async Task<List<Bills>> Get() =>
        await _barService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Bills>> Get(string id)
    {
        var user = await _barService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Bills newBills)
    {
        await _barService.CreateAsync(newBills);

        return CreatedAtAction(nameof(Get), new { id = newBills.Id }, newBills);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Bills updatedBills)
    {
        var user = await _barService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedBills.Id = user.Id;

        await _barService.UpdateAsync(id, updatedBills);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _barService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _barService.RemoveAsync(id);

        return NoContent();
    }
}