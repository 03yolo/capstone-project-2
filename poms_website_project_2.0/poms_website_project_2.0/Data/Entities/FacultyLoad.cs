using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class FacultyLoad
    {
        [Key]
        public int LoadId { get; set; }

        public int FacultyId { get; set; }

        public int SubjectId { get; set; }

        public int SectionId { get; set; }

        public int SchoolYearId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; } = null!;

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear SchoolYear { get; set; } = null!;

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; } = null!;

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; } = null!;
    }
}
