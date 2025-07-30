namespace poms_website_project_2._0.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
