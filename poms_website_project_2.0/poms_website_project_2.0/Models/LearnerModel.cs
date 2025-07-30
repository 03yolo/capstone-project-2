using System.Diagnostics;

namespace poms_website_project_2._0.Models
{
    public class LearnerModel
    {
        public int LearnerId { get; set; }

        public string Lrn { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public byte GradeLevel { get; set; }

        public virtual ICollection<AssessmentGradeModel> AssessmentGrades { get; set; } = new List<AssessmentGradeModel>();

        public virtual ICollection<AttendanceModel> Attendances { get; set; } = new List<AttendanceModel>();

        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();

        public virtual UserModel LearnerNavigation { get; set; } = null!;

        public virtual ICollection<ParentLearnerModel> ParentLearners { get; set; } = new List<ParentLearnerModel>();

        public virtual ICollection<SchoolFormModel> SchoolForms { get; set; } = new List<SchoolFormModel>();

        public virtual ICollection<SectionEnrolmentModel> SectionEnrolments { get; set; } = new List<SectionEnrolmentModel>();
    }
}
