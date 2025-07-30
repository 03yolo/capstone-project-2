using static System.Collections.Specialized.BitVector32;

namespace poms_website_project_2._0.Models
{
    public class SectionEnrolmentModel
    {
        public int EnrolId { get; set; }

        public int LearnerId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        public virtual LearnerModel Learner { get; set; } = null!;

        public virtual SchoolYearModel SchoolYear { get; set; } = null!;

        public virtual SectionModel Section { get; set; } = null!;
    }
}
