using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poms_website_project_2._0.Models
{
    public class AuditLogModel
    {
        [Key]
        public int LogId { get; set; }

        public int? UserId { get; set; }

        public string? Action { get; set; }

        public string? TableName { get; set; }

        public string? RecordPk { get; set; }

        public DateTime LogTime { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; } = null!;
    }
}
