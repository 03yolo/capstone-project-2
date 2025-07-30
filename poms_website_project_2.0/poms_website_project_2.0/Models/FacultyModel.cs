using System.Diagnostics;

namespace poms_website_project_2._0.Models
{
    public class FacultyModel
    {
        public int FacultyId { get; set; }

        public string EmployeeNo { get; set; } = null!;

        public string? Designation { get; set; }

        public virtual ICollection<AssessmentGradeModel> AssessmentGrades { get; set; } = new List<AssessmentGradeModel>();

        public virtual ICollection<FacultyLoadModel> FacultyLoads { get; set; } = new List<FacultyLoadModel>();

        public virtual UserModel FacultyNavigation { get; set; } = null!;

        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();
    }
}
