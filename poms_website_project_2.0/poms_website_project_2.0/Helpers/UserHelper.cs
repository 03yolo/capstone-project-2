using Microsoft.AspNetCore.Identity;
using poms_website_project_2._0.Models;
using poms_website_project_2._0.Repositories;
using poms_website_project_2._0.Data.Entities;


namespace poms_website_project_2._0.Helpers
{
    public class UserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILearnerRepository _learnerRepository;

        public UserHelper(
           UserManager<User> userManager,
           SignInManager<User> signInManager,
           RoleManager<IdentityRole> roleManager,
           ILearnerRepository  learnerRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _learnerRepository = learnerRepository;
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.LoginID,
                model.Password,
                model.RememberMe,
                false);
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task AddUserToRoleAsync(User user, int roleId)
        {
            string roleName = roleId switch
            {
                1 => "Admin",
                2 => "Faculty",
                3 => "Parent",
                4 => "Learner",
                _ => throw new ArgumentException("Invalid RoleId")
            };

            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
