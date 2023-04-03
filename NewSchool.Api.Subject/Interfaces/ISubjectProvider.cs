using System.Collections.Generic;

namespace NewSchool.Api.Subject.Interfaces
{
    public interface ISubjectProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Model.Subject>? Subject, string? ErrorMessage)> GetSubjectsAsync();
    }
}
