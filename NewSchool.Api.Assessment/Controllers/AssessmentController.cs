using Microsoft.AspNetCore.Mvc;
using NewSchool.Api.Assessment.Interfaces;

namespace NewSchool.Api.Assessment.Controllers
{
    [ApiController]
    [Route("/api/Assessment")]
    public class AssessmentController:ControllerBase
    {
        private readonly IAssessmentProvider _provider;
        public AssessmentController(IAssessmentProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsessmentAsync(int id)
        {
            var result = await _provider.GetAssesmentAsync(id);
            if(result.IsSuccess)
            {
                return Ok(result.Asessment);
            }
            else
                return NotFound();
        }
    }
}
