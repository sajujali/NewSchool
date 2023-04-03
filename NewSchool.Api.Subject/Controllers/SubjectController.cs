using Microsoft.AspNetCore.Mvc;
using NewSchool.Api.Subject.Interfaces;
using NewSchool.Api.Subject.Providers;

namespace NewSchool.Api.Subject.Controllers
{
    [ApiController]
    [Route("/api/subjects")]
    public class SubjectController : ControllerBase
    {
        public ISubjectProvider _provider { get; set; }
        
        public SubjectController(ISubjectProvider subjectProvider)
        {
            _provider = subjectProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            var result = await _provider.GetSubjectsAsync();
            if(result.IsSuccess)
                return Ok(result.Subject);
            else
                return NotFound();
        }
    }
}
