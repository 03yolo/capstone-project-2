using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class ParentLearnerModel
    {
        [Key]
        public int ParentId { get; set; }

        public int LearnerId { get; set; }

        public string? Relationship { get; set; }

        [ForeignKey("LearnerId")]
        public virtual LearnerModel Learner { get; set; } = null!;

        [ForeignKey("ParentId")]
        public virtual ParentModel Parent { get; set; } = null!;
    }
}
