namespace NewSchool.Api.Assessment.Interfaces
{
    public interface IAssessmentProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Model.Assessment>? Asessment, string? ErrorMessage)> GetAssesmentAsync(int id);
    }
}
