using System.ComponentModel.DataAnnotations.Schema;

namespace NewSchool.Api.Assessment.Model
{
    [Table("AssessmentSubject")]
    public class AssessmentSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int Mark { get; set; }
        [Column("AssesmentId")]
        public int AssessmentId { get; set; }
    }
}
