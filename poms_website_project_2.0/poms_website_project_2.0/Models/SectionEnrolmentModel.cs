using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace poms_website_project_2._0.Models
{
    public class SectionEnrolmentModel
    {
        [Key]

        public int EnrolId { get; set; }

        public int LearnerId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        [ForeignKey("LearnerId")]
        public virtual LearnerModel Learner { get; set; } = null!;

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYearModel SchoolYear { get; set; } = null!;

        [ForeignKey("SectionId")]
        public virtual SectionModel Section { get; set; } = null!;
    }
}
