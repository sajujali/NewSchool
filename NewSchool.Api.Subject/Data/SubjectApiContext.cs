using Microsoft.EntityFrameworkCore;

namespace NewSchool.Api.Subject.Data
{
    public class SubjectApiContext: DbContext
    {
        public DbSet<Model.Subject> subject { get; set; }
        public SubjectApiContext(DbContextOptions options) : base(options) { }
    }
}
