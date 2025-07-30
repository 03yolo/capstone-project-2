namespace poms_website_project_2._0.Models
{
    public class GradeModel
    {
        public int GradeId { get; set; }

        public int LearnerId { get; set; }

        public int FacultyId { get; set; }

        public int SubjectId { get; set; }

        public string Quarter { get; set; } = null!;

        public decimal? WwScore { get; set; }

        public decimal? WwTotal { get; set; }

        public decimal? WwPercentage { get; set; }

        public decimal? PtScore { get; set; }

        public decimal? PtTotal { get; set; }

        public decimal? PtPercentage { get; set; }

        public decimal? QaScore { get; set; }

        public decimal? QaTotal { get; set; }

        public decimal? QaPercentage { get; set; }

        public decimal? FinalGrade { get; set; }

        public string? Remarks { get; set; }

        public DateTime EncodedAt { get; set; }

        public virtual FacultyModel Faculty { get; set; } = null!;

        public virtual LearnerModel Learner { get; set; } = null!;

        public virtual SubjectModel Subject { get; set; } = null!;
    }
}
