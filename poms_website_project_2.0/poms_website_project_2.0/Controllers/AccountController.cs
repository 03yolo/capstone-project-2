using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Helpers;
using poms_website_project_2._0.Models;


namespace poms_website_project_2._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController (
            IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /*
        public async Task<IActionResult> LoginPage(poms_website_project_2._0.Models.LoginModel model)
        {
            
            if (ModelState.IsValid)
            {
                // Try to find user by Email or LRN
                UserModel? user;

                if (model.LoginID.Contains("@")) // assume email if it has '@'
                {
                    user = await _context.Users
                        .FirstOrDefaultAsync(u => u.Email == model.LoginID);
                }
                else // otherwise treat as LRN
                {
                    user = await _context.Users
                        .FirstOrDefaultAsync(u => u.LRN == model.LoginID);
                }

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                // Verify password (pseudo, depends if you use Identity or manual hashing)
                var passwordMatches = VerifyPassword(model.Password, user.PasswordHash);
                if (!passwordMatches)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                // Do sign-in
                await _signInManager.SignInAsync(user, model.RememberMe);

                // Redirect by role
                switch (user.RoleId)
                {
                    case 1: return RedirectToAction("AdminDashboard", "Dashboard");
                    case 2: return RedirectToAction("FacultyDashboard", "Dashboard");
                    case 3: return RedirectToAction("ParentDashboard", "Dashboard");
                    case 4: return RedirectToAction("LearnerDashboard", "Dashboard");
                    default: return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Failed to log in.");
            return View(model);
            
        }*/


        public async Task<IActionResult> FP_GetEmail()
        {
            return View();
        }

        public async Task<IActionResult> FP_GetPassword()
        {
            return View();
        }
    }
}
