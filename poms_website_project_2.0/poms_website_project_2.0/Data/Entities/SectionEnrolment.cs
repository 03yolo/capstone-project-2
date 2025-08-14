using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class SectionEnrolment
    {
        [Key]

        public int EnrolId { get; set; }

        public int LearnerId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        [ForeignKey("LearnerId")]
        public virtual Learner Learner { get; set; } = null!;

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear SchoolYear { get; set; } = null!;

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; } = null!;
    }
}
