using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Models
{
    public class SectionModel
    {
        [Key]

        public int SectionId { get; set; }

        public string SectionName { get; set; } = null!;

        public byte GradeLevel { get; set; }

        public virtual ICollection<FacultyLoadModel> FacultyLoads { get; set; } = new List<FacultyLoadModel>();

        public virtual ICollection<SectionEnrolmentModel> SectionEnrolments { get; set; } = new List<SectionEnrolmentModel>();
    }
}
