using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace poms_website_project_2._0.Controllers
{
    public class DashboardController : Controller
    {
        // Alert Repository Folder here [To be Added]

        public IActionResult Index()
        {
            return View();
        }

        // Checks the UserRoles and return View based on their role. ex. AdminDashboard.cshthml

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Faculty")]
        public async Task<IActionResult> FacultyDashboard()
        {
            return View();
        }
        [Authorize(Roles = "Learner")]
        public async Task<IActionResult> LearnerDashboard()
        {
            return View();
        }
        [Authorize(Roles = "Parent")]
        public async Task<IActionResult> ParentDashboard()
        {
            return View();
        }


    }
}
