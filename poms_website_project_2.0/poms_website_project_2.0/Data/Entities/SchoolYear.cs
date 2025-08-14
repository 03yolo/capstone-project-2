using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Data.Entities
{
    public class SchoolYear
    {
        [Key]

        public int SchoolYearId { get; set; }

        public short StartYear { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

        public virtual ICollection<Quarter> Quarters { get; set; } = new List<Quarter>();

        public virtual ICollection<SectionEnrolment> SectionEnrolments { get; set; } = new List<SectionEnrolment>();
    }
}
