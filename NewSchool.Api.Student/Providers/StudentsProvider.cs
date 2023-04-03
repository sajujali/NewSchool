using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Student.Data;
using NewSchool.Api.Student.Interfaces;

namespace NewSchool.Api.Student.Providers
{
    public class StudentsProvider : IStudentsProvider
    {
        private readonly StudentApiContext _context;

        private readonly ILogger<StudentsProvider> _logger;

        public StudentsProvider(StudentApiContext context, ILogger<StudentsProvider> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Model.Student>? Students, string? ErrorMessage)> GetStudentsAsync()
        {
            try
            {
                var result = await _context.Student.ToListAsync();
                if(result.Any() && result != null) {
                
                    return (true, result, null);
                }
                return (true, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }
            
        }
        
        public async Task<(bool IsSuccess, IEnumerable<Model.Student>? Students, string? ErrorMessage)> GetStudentsAsync(int id)
        {
            try
            {
                var result = await _context.Student.Where(s => s.Id == id).ToListAsync();
                //var student = result.Where(Student => Student.Id == id).FirstOrDefault();
                if (result.Any() && result != null)
                {

                    return (true, result, null);
                }
                return (true, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return (false, null, ex.Message);
            }

        }
    }
}
