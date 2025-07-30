using System.Data;

namespace poms_website_project_2._0.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual AdminDetailModel? AdminDetail { get; set; }

        public virtual FacultyModel? Faculty { get; set; }

        public virtual LearnerModel? Learner { get; set; }

        public virtual ICollection<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();

        public virtual ParentModel? Parent { get; set; }

        public virtual RoleModel Role { get; set; } = null!;

        public virtual ICollection<SchoolFormModel> SchoolForms { get; set; } = new List<SchoolFormModel>();
    }
}
