using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Student.Model;

namespace NewSchool.Api.Student.Data
{
    public class StudentApiContext: DbContext
    {
        public DbSet<Model.Student> Student { get; set; }
        public StudentApiContext(DbContextOptions options) : base(options) 
        { }
    }
}
