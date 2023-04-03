using NewSchool.Api.Search.Model;

namespace NewSchool.Api.Search.Interfaces
{
    public interface IAssessmentService
    {
        Task<(bool IsSuccess, IEnumerable<Assessment>? Assessment, string? ErrorMessage)> GetAssessmentAsync(int studentId);
    }
}
