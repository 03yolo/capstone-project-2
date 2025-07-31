using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class ParentModel
    {
        [Key] 
        [ForeignKey("ParentNavigation")]
        public int UserId { get; set; }

        public virtual ICollection<ParentLearnerModel> ParentLearners { get; set; } = new List<ParentLearnerModel>();

        public virtual UserModel ParentNavigation { get; set; } = null!;
    }
}
