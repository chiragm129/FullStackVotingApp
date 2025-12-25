using Microsoft.EntityFrameworkCore;
using VoteApi.Models;

namespace VoteApi.Data;

public class VotingDbContext : DbContext
{
    public VotingDbContext(DbContextOptions<VotingDbContext> options)
        : base(options) { }

    public DbSet<Voter> Voters => Set<Voter>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
}
