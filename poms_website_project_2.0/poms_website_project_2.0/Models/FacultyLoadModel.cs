using static System.Collections.Specialized.BitVector32;

namespace poms_website_project_2._0.Models
{
    public class FacultyLoadModel
    {
        public int LoadId { get; set; }

        public int FacultyId { get; set; }

        public int SubjectId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        public virtual FacultyModel Faculty { get; set; } = null!;

        public virtual SchoolYearModel SchoolYear { get; set; } = null!;

        public virtual SectionModel Section { get; set; } = null!;

        public virtual SubjectModel Subject { get; set; } = null!;
    }
}
