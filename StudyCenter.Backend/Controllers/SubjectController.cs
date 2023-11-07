using Microsoft.AspNetCore.Mvc;

namespace StudyCenter.Backend.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
