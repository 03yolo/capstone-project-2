using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email or LRN is Required.")]
        [Display(Name = "Email or LRN")]
        public string LoginID { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "Password must be at least {1} characters long.")]

        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
