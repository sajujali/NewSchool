using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Subject.Data;
using NewSchool.Api.Subject.Interfaces;

namespace NewSchool.Api.Subject.Providers
{
    public class SubjectProvider : ISubjectProvider
    {
        private readonly SubjectApiContext _context;
        private readonly ILogger<SubjectProvider> _logger;
        public SubjectProvider(SubjectApiContext context,ILogger<SubjectProvider> logger) 
        {   
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Model.Subject>? Subject, string? ErrorMessage)> GetSubjectsAsync()
        {
            try
            {
                var result = await _context.subject.ToListAsync();
                if (result.Any() && result != null)
                {
                    return (true, result, null);
                }
                else
                {
                    return (false, null, "Not Found");
                }
            }catch(Exception ex) 
            {
                _logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
