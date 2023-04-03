using Microsoft.AspNetCore.Http.HttpResults;
using NewSchool.Api.Search.Interfaces;
using NewSchool.Api.Search.Model;
using System.Collections;
using System.Text.Json;

namespace NewSchool.Api.Search.Service
{
    public class AssessmentService :IAssessmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AssessmentService> _logger;
        public AssessmentService(IHttpClientFactory httpClientFactory, ILogger<AssessmentService> logger) 
        { 
            this._httpClientFactory = httpClientFactory;
            this._logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Assessment>? Assessment, string? ErrorMessage)> GetAssessmentAsync(int studentId)
        {
            try
            {
                //var client = _httpClientFactory.CreateClient("AsessmentService");
                var client = _httpClientFactory.CreateClient("AssessmentService");
                
                var response = await client.GetAsync($"api/Assessment/{studentId}");
                if(response.IsSuccessStatusCode) 
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions(){PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Assessment>>(content,options);
                    return (true,result,null);
                }
                return (false, null, response.ReasonPhrase);

            }catch(Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return(false,null,ex.ToString());
            }

        }
    }
}
