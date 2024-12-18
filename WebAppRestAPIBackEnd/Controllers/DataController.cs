using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppRestAPIBackEnd.Model;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly AppDbContext _context;

    public DataController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DBData>>> GetDBData()
    {
        return await _context.DBData.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DBData>> GetDBData(int id)
    {
        var data = await _context.DBData.FindAsync(id);

        if (data == null)
        {
            return NotFound();
        }

        return data;
    }

    [HttpPost]
    public async Task<ActionResult<DBData>> PostDBData(DBData data)
    {
        _context.DBData.Add(data);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDBData", new { id = data.Id }, data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDBData(int id, DBData data)
    {
        if (id != data.Id)
        {
            return BadRequest();
        }

        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDBData(int id)
    {
        var data = await _context.DBData.FindAsync(id);
        if (data == null)
        {
            return NotFound();
        }

        _context.DBData.Remove(data);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
