using Microsoft.AspNetCore.Mvc;

namespace EPayCar.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
