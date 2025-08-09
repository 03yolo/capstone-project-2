using Microsoft.AspNetCore.Mvc;

namespace poms_website_project_2._0.Controllers
{
    public class OtherPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FAQs()
        {
            return View();
        }

        public async Task<IActionResult> HelpCenter()
        {
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            return View();
        }
    }
}
