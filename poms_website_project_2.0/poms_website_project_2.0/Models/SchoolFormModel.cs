namespace poms_website_project_2._0.Models
{
    public class SchoolFormModel
    {
        [Key]

        public int FormId { get; set; }

        public int LearnerId { get; set; }

        public string FormType { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int GeneratedBy { get; set; }

        public DateTime GeneratedAt { get; set; }

        public virtual UserModel GeneratedByNavigation { get; set; } = null!;

        public virtual LearnerModel Learner { get; set; } = null!;
    }
}
