using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Assessment.Data;
using NewSchool.Api.Assessment.Interfaces;

namespace NewSchool.Api.Assessment.Providers
{
    public class AssessmentProvider : IAssessmentProvider
    {
        public readonly AssessmentApiContext _context;
        public readonly ILogger<AssessmentProvider> _logger;

        public AssessmentProvider(AssessmentApiContext context, ILogger<AssessmentProvider> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Model.Assessment>? Asessment, string? ErrorMessage)> GetAssesmentAsync(int id)
        {

            try
            {
                var result = await _context.Assessment
                .Where(Assessment => Assessment.Id == id)
                .Include(a => a.Items).ToListAsync();
                if (result != null && result.Any())
                {
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
