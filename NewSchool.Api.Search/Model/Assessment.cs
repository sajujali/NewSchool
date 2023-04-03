namespace NewSchool.Api.Search.Model
{
    public class Assessment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StudentId { get; set; }
        //public int Total { get; set; }
        public List<AssessmentItem>? Items { get; set; }
    }
}
