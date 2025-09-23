using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class Learner
    {
        [Key]
        [ForeignKey("LearnerNavigation")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Learner's LRN is required.")]
        public string Lrn { get; set; } = null!;

        [Required(ErrorMessage = "Learner's birth date is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Learner's grade level is required.")]
        public byte GradeLevel { get; set; }

        public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        public virtual User LearnerNavigation { get; set; } = null!;

        public virtual ICollection<ParentLearner> ParentLearners { get; set; } = new List<ParentLearner>();

        public virtual ICollection<SchoolForm> SchoolForms { get; set; } = new List<SchoolForm>();

        public virtual ICollection<SectionEnrolment> SectionEnrolments { get; set; } = new List<SectionEnrolment>();
    }
}
