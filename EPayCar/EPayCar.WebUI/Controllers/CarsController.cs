using EPayCar.Core.Service;
using Microsoft.AspNetCore.Mvc;
using EPayCar.Model.Entities;



namespace EPayCar.WebUI.Controllers
{
    public class CarsController : Controller
    {
        private readonly IDbService<Carscs> _db;

        public CarsController(IDbService<Carscs > db)
        {
            _db = db;
        }

        public IActionResult Detail(int id)
        {
            return View(_db.GetById(id));
        }
    }
}
