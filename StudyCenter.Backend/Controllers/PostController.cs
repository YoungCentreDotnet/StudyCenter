using Microsoft.AspNetCore.Mvc;

namespace StudyCenter.Backend.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
