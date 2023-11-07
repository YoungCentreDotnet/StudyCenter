using Microsoft.AspNetCore.Mvc;

namespace StudyCenter.Backend.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
