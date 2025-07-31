using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class AdminDetailModel
    {
        [Key]
        [ForeignKey("Admin")]
        public int UserId { get; set; }

        public string Position { get; set; } = null!;

        public string? Office { get; set; }

        public string? ContactNo { get; set; }

        public virtual UserModel Admin { get; set; } = null!;
    }
}
