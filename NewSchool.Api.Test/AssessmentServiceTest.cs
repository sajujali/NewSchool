using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NewSchool.Api.Assessment.Data;
using NewSchool.Api.Assessment.Providers;

namespace NewSchool.Api.Assessment.Test
{
    public class AssessmentServiceTest
    {
        [Fact]
        public async void GetAsessmentById()
        {

            var options = new DbContextOptionsBuilder<AssessmentApiContext>()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False").Options;
            var dbContext = new AssessmentApiContext(options);
           //ILogger<AssessmentProvider> logger = new 
            var assessmentProvider = new AssessmentProvider(dbContext, new NullLogger<AssessmentProvider>());
            var assessment = await assessmentProvider.GetAssesmentAsync(1);
            Assert.True(assessment.IsSuccess);
            Assert.True(assessment.Asessment.Any());
            Assert.Null(assessment.ErrorMessage);
        }
    }
}