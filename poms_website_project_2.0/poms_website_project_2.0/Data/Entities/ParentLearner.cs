using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class ParentLearner
    {
        [Key]
        public int ParentId { get; set; }

        public int LearnerId { get; set; }

        public string? Relationship { get; set; }

        [ForeignKey("LearnerId")]
        public virtual Learner Learner { get; set; } = null!;

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; } = null!;
    }
}
