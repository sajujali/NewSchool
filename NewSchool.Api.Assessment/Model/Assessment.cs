namespace NewSchool.Api.Assessment.Model
{
    public class Assessment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StudentId { get; set; }
        //public int Total { get; set; }
        public List<AssessmentSubject>? Items { get; set; }
    }
}
