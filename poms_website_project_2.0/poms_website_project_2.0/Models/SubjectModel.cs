using System.Diagnostics;

namespace poms_website_project_2._0.Models
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }

        public string SubjectCode { get; set; } = null!;

        public string SubjectName { get; set; } = null!;

        public virtual ICollection<AssessmentGradeModel> AssessmentGrades { get; set; } = new List<AssessmentGradeModel>();

        public virtual ICollection<FacultyLoadModel> FacultyLoads { get; set; } = new List<FacultyLoadModel>();

        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();
    }
}
