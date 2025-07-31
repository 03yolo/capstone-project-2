using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Models
{
    public class SchoolYearModel
    {
        [Key]

        public int SchoolYearId { get; set; }

        public short StartYear { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<FacultyLoadModel> FacultyLoads { get; set; } = new List<FacultyLoadModel>();

        public virtual ICollection<QuarterModel> Quarters { get; set; } = new List<QuarterModel>();

        public virtual ICollection<SectionEnrolmentModel> SectionEnrolments { get; set; } = new List<SectionEnrolmentModel>();
    }
}
