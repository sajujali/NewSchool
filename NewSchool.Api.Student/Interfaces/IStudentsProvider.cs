namespace NewSchool.Api.Student.Interfaces
{
    public interface IStudentsProvider
    {
       Task<(bool IsSuccess, IEnumerable<Model.Student>? Students, string? ErrorMessage)> GetStudentsAsync();
        Task<(bool IsSuccess, IEnumerable<Model.Student>? Students, string? ErrorMessage)> GetStudentsAsync(int id);
    }
}
