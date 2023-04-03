using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Assessment.Model;
namespace NewSchool.Api.Assessment.Data
{
    public class AssessmentApiContext: DbContext
    {
        public DbSet<Model.Assessment> Assessment { get; set; }
        public DbSet<AssessmentSubject> AssessmentItems { get; set; }

        public AssessmentApiContext(DbContextOptions options) : base(options) 
        { }
    }
}
