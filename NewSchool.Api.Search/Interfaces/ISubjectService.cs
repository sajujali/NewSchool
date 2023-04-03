using NewSchool.Api.Search.Model;

namespace NewSchool.Api.Search.Interfaces
{
    public interface ISubjectService
    {
        Task<(bool IsSuccess, IEnumerable<Subject> Subject, string ErrorMessage)> GetSubjectAsync();
    }
}
