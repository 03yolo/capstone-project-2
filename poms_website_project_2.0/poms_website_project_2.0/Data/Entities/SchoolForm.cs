using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class SchoolForm
    {
        [Key]

        public int FormId { get; set; }

        public int LearnerId { get; set; }

        public string FormType { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int GeneratedBy { get; set; }

        public DateTime GeneratedAt { get; set; }

        public virtual User GeneratedByNavigation { get; set; } = null!;

        [ForeignKey("LearnerId")]
        public virtual Learner Learner { get; set; } = null!;
    }
}
