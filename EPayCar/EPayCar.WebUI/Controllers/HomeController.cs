using EPayCar.Core.Service;
using Microsoft.AspNetCore.Mvc;
using EPayCar.Model.Entities;
namespace EPayCar.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService<Carbrands> _db;

        public HomeController(IDbService<Carbrands> db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetAll());
        }

        public IActionResult Brands()
        {
            return View(_db.GetAll());
        }
    }
}
