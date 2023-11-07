using Microsoft.AspNetCore.Mvc;

namespace StudyCenter.Backend.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
