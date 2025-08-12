using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class Faculty
    {
        [Key]
        [ForeignKey("FacultyNavigation")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Employee Number is required.")]
        public string EmployeeNo { get; set; } = null!;

        public string? Designation { get; set; }

        public virtual ICollection<AssessmentGradeModel> AssessmentGrades { get; set; } = new List<AssessmentGradeModel>();

        public virtual ICollection<FacultyLoadModel> FacultyLoads { get; set; } = new List<FacultyLoadModel>();

        public virtual UserModel FacultyNavigation { get; set; } = null!;

        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();
    }
}
