using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace poms_website_project_2._0.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> LoginPage()
        {
            return View();
        }

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
