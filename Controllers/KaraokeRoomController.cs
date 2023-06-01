using karaokeWEBAPI.Models;
using karaokeWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace karaokeWEBAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KaraokeRoomController : ControllerBase
{
    private readonly KaraokeRoomService _karaokeroomService;

    public KaraokeRoomController(KaraokeRoomService karaokeroomService) =>
        _karaokeroomService = karaokeroomService;

    [HttpGet]
    public async Task<List<KaraokeRoom>> Get() =>
        await _karaokeroomService.GetAsync();
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<KaraokeRoom>> Get(string id)
    {
        var karaokeroom = await _karaokeroomService.GetAsync(id);

        if (karaokeroom is null)
        {
            return NotFound();
        }

        return karaokeroom;
    }
    [HttpPost]
    public async Task<IActionResult> Post(KaraokeRoom newkaraokeRoom)
    {
        await _karaokeroomService.CreateAsync(newkaraokeRoom);

        return CreatedAtAction(nameof(Get), new { id = newkaraokeRoom.Id }, newkaraokeRoom);
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, KaraokeRoom updatedkaraokeRoom)
    {
        var karaokeroom = await _karaokeroomService.GetAsync(id);

        if (karaokeroom is null)
        {
            return NotFound();
        }

        updatedkaraokeRoom.Id = karaokeroom.Id;

        await _karaokeroomService.UpdateAsync(id, updatedkaraokeRoom);

        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var karaokeroom = await _karaokeroomService.GetAsync(id);

        if (karaokeroom is null)
        {
            return NotFound();
        }

        await _karaokeroomService.RemoveAsync(id);

        return NoContent();
    }
}

