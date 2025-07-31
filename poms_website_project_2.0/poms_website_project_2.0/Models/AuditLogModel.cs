using System.ComponentModel.DataAnnotations;

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
    }
}
