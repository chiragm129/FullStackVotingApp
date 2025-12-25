using Microsoft.AspNetCore.Mvc;
using VoteApi.Data;
using VoteApi.Models;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("api/candidates")]
public class CandidatesController : ControllerBase
{
    private readonly VotingDbContext _context;

    public CandidatesController(VotingDbContext context)
    {
        _context = context;
    }

    // Get all candidates (table + dropdown)
    [HttpGet]
    public IActionResult GetCandidates()
    {
        return Ok(_context.Candidates.ToList());
    }

    // Add candidate
    [HttpPost]
    public IActionResult AddCandidate([FromBody] string name)
    {
        var candidate = new Candidate
        {
            Name = name,
            Votes = 0
        };

        _context.Candidates.Add(candidate);
        _context.SaveChanges();

        return Ok(candidate);
    }
}
