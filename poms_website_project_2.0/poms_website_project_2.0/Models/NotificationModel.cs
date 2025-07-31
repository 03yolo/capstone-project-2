using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class NotificationModel
    {
        [Key]

        public int NotificationId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; } = null!;
    }
}
