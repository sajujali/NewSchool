namespace NewSchool.Api.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int StudentId);
    }
}
