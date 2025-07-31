using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Models
{
    public class QuarterModel
    {
        [Key]

        public int QuarterId { get; set; }

        public int SchoolYearId { get; set; }

        public byte QuarterNo { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public virtual ICollection<AssessmentGradeModel> AssessmentGrades { get; set; } = new List<AssessmentGradeModel>();

        public virtual SchoolYearModel SchoolYear { get; set; } = null!;
    }
}
