using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitesApi.Data;
using SitesApi.Models;

namespace SitesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SitesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SitesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Sites
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Site>>> GetSites()
    {
        return await _context.Sites.ToListAsync();
    }

    // GET: api/Sites/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Site>> GetSite(int id)
    {
        var site = await _context.Sites.FindAsync(id);
        if (site == null)
            return NotFound();

        return site;
    }

    // POST: api/Sites
    [HttpPost]
    public async Task<ActionResult<Site>> PostSite(Site site)
    {
        _context.Sites.Add(site);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSite), new { id = site.SiteId }, site);
    }

    // PUT: api/Sites/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSite(int id, Site site)
    {
        if (id != site.SiteId)
            return BadRequest();

        _context.Entry(site).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sites.Any(e => e.SiteId == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Sites/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSite(int id)
    {
        var site = await _context.Sites.FindAsync(id);
        if (site == null)
            return NotFound();

        _context.Sites.Remove(site);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
