using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Data.Entities
{
    public class AdminDetail
    {
        [Key]
        [ForeignKey("Admin")]
        public int UserId { get; set; }

        public string Position { get; set; } = null!;

        public string? Office { get; set; }

        public string? ContactNo { get; set; }

        public virtual User Admin { get; set; } = null!;
    }
}
