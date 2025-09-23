using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class Parent
    {
        [Key]
        [ForeignKey("ParentNavigation")]
        public int UserId { get; set; }

        public virtual ICollection<ParentLearner> ParentLearners { get; set; } = new List<ParentLearner>();

        public virtual User ParentNavigation { get; set; } = null!;
    }
}
