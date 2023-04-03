using Microsoft.Extensions.Configuration.Json;
using NewSchool.Api.Search.Interfaces;
using NewSchool.Api.Search.Model;
using System.Text.Json;

namespace NewSchool.Api.Search.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        public SubjectService(IHttpClientFactory httpClientFactory, ILogger<SubjectService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Subject> Subject, string ErrorMessage)> GetSubjectAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("SubjectService");
                var result = await client.GetAsync("api/subjects");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result1 = JsonSerializer.Deserialize<IEnumerable<Subject>>(content,options);
                    return (true, result1, null);

                }
                return (false, null, result.ReasonPhrase);

            }catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return(false,null,ex.ToString());
            }
        }
    }

}
