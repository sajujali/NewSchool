using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpClient httpClient = new HttpClient();
            string uri = "https://newschool-saju.azurewebsites.net/weatherforecast";
            var response = httpClient.GetAsync(uri).Result;
            var content = response.Content.ReadAsStringAsync();

        }
    }
}