using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TVMazeScraper.Data;

namespace TVMazeScraper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShowsController : ControllerBase
{
    private readonly TVMazeContext _context;

    public ShowsController(TVMazeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetShows(int pageNumber = 1, int pageSize = 10)
    {
        if (pageNumber <= 0 || pageSize <= 0)
        {
            return BadRequest("Page number and page size must be greater than 0.");
        }

        var shows = await _context.Shows
            .Include(s => s.Cast)
            .ThenInclude(c => c.person)
            .OrderBy(s => s.id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var result = shows.Select(show => new
            {
                show.id,
                show.name,
                Cast = show.Cast
                    .OrderByDescending(c => c.person.birthday)
                    .Select(c => new { c.person.id, c.person.name, c.person.birthday })
            });

        return Ok(result);
    }
}
