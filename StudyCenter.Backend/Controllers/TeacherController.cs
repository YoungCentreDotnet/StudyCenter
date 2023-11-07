using Microsoft.AspNetCore.Mvc;

namespace StudyCenter.Backend.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
