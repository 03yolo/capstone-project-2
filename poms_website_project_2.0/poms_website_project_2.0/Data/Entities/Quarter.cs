using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class Quarter
    {
        [Key]

        public int QuarterId { get; set; }

        public int SchoolYearId { get; set; }

        public byte QuarterNo { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear SchoolYear { get; set; } = null!;
    }
}
