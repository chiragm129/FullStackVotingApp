using Microsoft.AspNetCore.Mvc;
using VoteApi.Data;
using VoteApi.Models;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("api/votes")]
public class VotesController : ControllerBase
{
    private readonly VotingDbContext _context;

    public VotesController(VotingDbContext context)
    {
        _context = context;
    }

    [HttpPost("cast")]
    public IActionResult CastVote([FromBody] CastVoteDto dto)
    {
        var voter = _context.Voters.FirstOrDefault(v => v.Id == dto.VoterId);
        if (voter == null || voter.HasVoted)
            return BadRequest("Voter not valid or already voted");

        var candidate = _context.Candidates.FirstOrDefault(c => c.Id == dto.CandidateId);
        if (candidate == null)
            return BadRequest("Candidate not valid");

        // CORE FUNCTIONALITY
        voter.HasVoted = true;
        candidate.Votes++;

        _context.SaveChanges();

        return Ok(new
        {
            Message = "Vote cast successfully"
        });
    }
}
