namespace poms_website_project_2._0.Models
{
    public class AssessmentGradeModel
    {
        public int AssessmentGradeId { get; set; }

        public int LearnerId { get; set; }

        public int SubjectId { get; set; }

        public int FacultyId { get; set; }

        public int QuarterId { get; set; }

        public string AssessmentType { get; set; } = null!;

        public int AssessmentNo { get; set; }

        public decimal Score { get; set; }

        public int TotalItems { get; set; }

        public DateOnly? DateGiven { get; set; }

        public string Remarks { get; set; } = null!;

        public virtual FacultyModel Faculty { get; set; } = null!;

        public virtual LearnerModel Learner { get; set; } = null!;

        public virtual QuarterModel Quarter { get; set; } = null!;

        public virtual SubjectModel Subject { get; set; } = null!;
    }
}
