using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfitController : ControllerBase, IBarController<Profit, ProfitService>
{
    public ProfitService _barService { get; set; }

    public ProfitController(ProfitService usersService) =>
        _barService = usersService;

    [HttpGet]
    public async Task<List<Profit>> Get() =>
        await _barService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Profit>> Get(string id)
    {
        var user = await _barService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Profit newProfit)
    {
        await _barService.CreateAsync(newProfit);

        return CreatedAtAction(nameof(Get), new { id = newProfit.Id }, newProfit);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Profit updatedProfit)
    {
        var user = await _barService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedProfit.Id = user.Id;

        await _barService.UpdateAsync(id, updatedProfit);

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