using System.ComponentModel.DataAnnotations.Schema;

namespace NewSchool.Api.Search.Model
{
    public class AssessmentItem
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Mark { get; set; }
        [Column("AssesmentId")]
        public int AssessmentId { get; set; }
    }
}
