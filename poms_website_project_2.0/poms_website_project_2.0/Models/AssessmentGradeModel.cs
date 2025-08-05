using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class AssessmentGradeModel
    {
        [Key]
        public int AssessmentGradeId { get; set; }

        public int LearnerId { get; set; }

        public int SubjectId { get; set; }

        public int FacultyId { get; set; }

        public int QuarterId { get; set; }
        public int AssessmentId { get; set; }

        public decimal Score { get; set; }

        public DateOnly? DateGiven { get; set; }

        public string Remarks { get; set; } = null!;

        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculty { get; set; } = null!;

        [ForeignKey("LearnerId")]
        public virtual LearnerModel Learner { get; set; } = null!;

        [ForeignKey("QuarterId")]
        public virtual QuarterModel Quarter { get; set; } = null!;

        [ForeignKey("SubjectId")]
        public virtual SubjectModel Subject { get; set; } = null!;

        [ForeignKey("AssessmentId")]
        public virtual AssessmentModel Assessment { get; set; } = null!;

    }
}
