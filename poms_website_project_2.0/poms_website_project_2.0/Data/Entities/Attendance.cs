using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int LearnerId { get; set; }

        public DateOnly SchoolDate { get; set; }

        // 1: PRESENT - 2: ABSENT - 3: LATE
        public int AttendanceStatus { get; set; }

        [ForeignKey("LearnerId")]
        public virtual Learner Learner { get; set; } = null!;
    }
}
