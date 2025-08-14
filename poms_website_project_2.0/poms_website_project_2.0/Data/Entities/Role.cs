using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Data.Entities
{
    public class Role
    {
        [Key]

        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
