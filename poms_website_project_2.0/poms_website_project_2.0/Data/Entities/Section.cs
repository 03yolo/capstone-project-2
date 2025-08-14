using poms_website_project_2._0.Models;

namespace poms_website_project_2._0.Data.Entities
{
    public class Section
    {
        public int SectionId { get; set; }

        public string SectionName { get; set; } = null!;

        public byte GradeLevel { get; set; }

        public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

        public virtual ICollection<SectionEnrolment> SectionEnrolments { get; set; } = new List<SectionEnrolment>();
    }
}
