using Microsoft.AspNetCore.Mvc;
using NewSchool.Api.Search.Interfaces;
using NewSchool.Api.Search.Model;

namespace NewSchool.Api.Search.Controllers
{
    [ApiController]
    [Route("/api/search")]
    public class SearchController: ControllerBase
    {
        public readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        { _searchService = searchService; }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm searchstring)
        {
            var result = await _searchService.SearchAsync(searchstring.StudentId);
            if(result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }

    }
}
