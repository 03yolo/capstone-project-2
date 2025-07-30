namespace poms_website_project_2._0.Models
{
    public class AttendanceModel
    {
        public int AttendanceId { get; set; }

        public int LearnerId { get; set; }

        public DateOnly SchoolDate { get; set; }

        public bool IsPresent { get; set; }

        public virtual LearnerModel Learner { get; set; } = null!;
    }
}
