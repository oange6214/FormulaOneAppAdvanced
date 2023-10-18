
using FormulaOneApp.Data;
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")] // api/teams
[ApiController]
public class TeamsController : ControllerBase
{
    private static AppDbContext _context = null!;

    public TeamsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teams = await _context.Teams.ToListAsync();
        return Ok(teams);    // return 200
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        return Ok(team);    // return 200
    }

    [HttpPost]
    public async Task<IActionResult> Post(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", team.Id, team);   // return 201
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, string country)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        team.Country = country;

        await _context.SaveChangesAsync();

        return NoContent(); // return 204
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}