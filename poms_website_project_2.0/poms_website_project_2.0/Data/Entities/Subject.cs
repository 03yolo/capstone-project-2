using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Data.Entities
{
    public class Subject
    {
        [Key]

        public int SubjectId { get; set; }

        public string SubjectCode { get; set; } = null!;

        public string SubjectName { get; set; } = null!;

        public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

        public virtual ICollection<FacultyLoad> FacultyLoads { get; set; } = new List<FacultyLoad>();

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
