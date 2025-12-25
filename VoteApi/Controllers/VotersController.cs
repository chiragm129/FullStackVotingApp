using Microsoft.AspNetCore.Mvc;
using VoteApi.Data;
using VoteApi.Models;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("api/voters")]
public class VotersController : ControllerBase
{
    private readonly VotingDbContext _context;

    public VotersController(VotingDbContext context)
    {
        _context = context;
    }

    // Get all voters (table + dropdown)
    [HttpGet]
    public IActionResult GetVoters()
    {
        return Ok(_context.Voters.ToList());
    }

    // Add voter
    [HttpPost]
    public IActionResult AddVoter([FromBody] string name)
    {
        var voter = new Voter
        {
            Name = name,
            HasVoted = false
        };

        _context.Voters.Add(voter);
        _context.SaveChanges();

        return Ok(voter);
    }
}
