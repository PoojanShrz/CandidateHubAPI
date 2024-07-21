using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandidateHubAPI.Data;
using CandidateHubAPI.Models;
using System.Threading.Tasks;

namespace CandidateHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateDbContext _context;

        public CandidatesController(CandidateDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCandidate(Candidate candidate)
        {
            var existingCandidate = await _context.Candidates.SingleOrDefaultAsync(c => c.Email == candidate.Email);
            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.BestTimetoCall = candidate.BestTimetoCall;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.FreeTextComment = candidate.FreeTextComment;
                _context.Candidates.Update(existingCandidate);
            }
            else
            {
                await _context.Candidates.AddAsync(candidate);
            }
            await _context.SaveChangesAsync();
            return Ok(candidate);
        }
    }
}
