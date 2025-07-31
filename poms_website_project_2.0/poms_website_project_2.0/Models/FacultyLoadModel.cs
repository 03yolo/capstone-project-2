using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace poms_website_project_2._0.Models
{
    public class FacultyLoadModel
    {
        [Key]
        public int LoadId { get; set; }

        public int FacultyId { get; set; }

        public int SubjectId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculty { get; set; } = null!;

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYearModel SchoolYear { get; set; } = null!;

        [ForeignKey("SectionId")]
        public virtual SectionModel Section { get; set; } = null!;

        [ForeignKey("SubjectId")]
        public virtual SubjectModel Subject { get; set; } = null!;
    }
}
