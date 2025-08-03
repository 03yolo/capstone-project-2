using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class AssessmentModel
    {
        [Key]
        public int AssessmentId { get; set; }

        public int SubjectId { get; set; }

        public int FacultyId { get; set; }

        public int QuarterId { get; set; }

        public string AssessmentName { get; set; } = null!;

        public string AssessmentType { get; set; } = null!;

        public int AssessmentNo { get; set; }

        public int TotalItems { get; set; }

        public DateOnly? DateGiven { get; set; }


        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculty { get; set; } = null!;

        [ForeignKey("SchoolYearId")]
        public virtual QuarterModel Quarter { get; set; } = null!;

        [ForeignKey("SubjectId")]
        public virtual SubjectModel Subject { get; set; } = null!;
    }
}
