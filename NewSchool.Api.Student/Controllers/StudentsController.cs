using Microsoft.AspNetCore.Mvc;
using NewSchool.Api.Student.Interfaces;

namespace NewSchool.Api.Student.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsProvider _provider;
        public StudentsController(IStudentsProvider provider)
        {
            this._provider = provider;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _provider.GetStudentsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Students);
            }
            else
            { 
                return NotFound(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsAsync(int id)
        {
            var result = await _provider.GetStudentsAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Students);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
