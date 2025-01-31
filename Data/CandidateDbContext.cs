using Microsoft.EntityFrameworkCore;
using CandidateHubAPI.Models;

namespace CandidateHubAPI.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
