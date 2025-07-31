using System.ComponentModel.DataAnnotations;
using System.Data;

namespace poms_website_project_2._0.Models
{
    public class UserModel
    {
        // Unique identifier
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        // 1 = Admin, 2 = Faculty, 3 = Parent, 4 = Learner
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }

        // Email address
        [Display(Name = "Email Address")]
        public string Email { get; set; } = null!;

        // Hashed password
        [Display(Name = "Password")]
        public string PasswordHash { get; set; } = null!;

        // Name of the user
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "First Name")]

        public string FirstName { get; set; } = null!;

        [Display(Name = "Middle Name")]

        public string MiddleName { get; set; } = null!;

        // Active or deactivated?
        public bool IsActive { get; set; }

        //When was the account created?
        public DateTime CreatedAt { get; set; }

        // Assigns the user to their respective role
        public virtual AdminDetailModel? AdminDetail { get; set; }

        public virtual FacultyModel? Faculty { get; set; }

        public virtual LearnerModel? Learner { get; set; }

        // A user can have many notifications
        public virtual ICollection<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();

        public virtual ParentModel? Parent { get; set; }

        public virtual RoleModel Role { get; set; } = null!;

        // Admin can handle many school forms
        public virtual ICollection<SchoolFormModel> SchoolForms { get; set; } = new List<SchoolFormModel>();
    }
}
