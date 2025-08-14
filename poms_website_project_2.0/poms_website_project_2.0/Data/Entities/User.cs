using poms_website_project_2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Data.Entities
{
    public class User
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
        public virtual AdminDetail? AdminDetail { get; set; }

        public virtual Faculty? Faculty { get; set; }

        public virtual Learner? Learner { get; set; }

        // A user can have many notifications
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        public virtual Parent? Parent { get; set; }

        public virtual Role Role { get; set; } = null!;

        // Admin can handle many school forms
        public virtual ICollection<SchoolForm> SchoolForms { get; set; } = new List<SchoolForm>();
    }
}
