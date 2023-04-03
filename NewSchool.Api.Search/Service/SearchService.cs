using NewSchool.Api.Search.Interfaces;
using NewSchool.Api.Search.Model;

namespace NewSchool.Api.Search.Service
{
    public class SearchService: ISearchService
    {
        private readonly IAssessmentService assessmentService;
        private readonly ISubjectService subjectService;
        public SearchService(IAssessmentService assessmentService, ISubjectService subjectService)
        {
            this.assessmentService = assessmentService;
            this.subjectService = subjectService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int StudentId)
        {
            var assessmentResult = await assessmentService.GetAssessmentAsync(StudentId);
            var subjectResult = await subjectService.GetSubjectAsync();
            if (assessmentResult.IsSuccess)
            {
                foreach(var assessment in assessmentResult.Assessment) 
                {
                    foreach(var item in assessment.Items)
                    {
                        item.SubjectName = subjectResult.Subject.FirstOrDefault(s => s.id == item.SubjectId)?.name;
                    }
                }
                var result1 = new
                {
                    Assessment = assessmentResult.Assessment
                };
                return (true, result1);
            }
            return (false, null);
        }


    }
}
