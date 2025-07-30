namespace poms_website_project_2._0.Models
{
    public class ParentLearnerModel
    {
        public int ParentId { get; set; }

        public int LearnerId { get; set; }

        public string? Relationship { get; set; }

        public virtual LearnerModel Learner { get; set; } = null!;

        public virtual ParentModel Parent { get; set; } = null!;
    }
}
