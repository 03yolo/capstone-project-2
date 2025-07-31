using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class AttendanceModel
    {
        [Key]
        public int AttendanceId { get; set; }

        public int LearnerId { get; set; }

        public DateOnly SchoolDate { get; set; }

        public bool IsPresent { get; set; }

        [ForeignKey("LearnerId")]
        public virtual LearnerModel Learner { get; set; } = null!;
    }
}
