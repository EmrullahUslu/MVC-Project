using EPayCar.Core.Service;
using EPayCar.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPayCar.WebUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IDbService<Carscs> _db;

        public BrandController(IDbService<Carscs> db)
        {
            _db = db;
        }
        public IActionResult Cars(int id)
        {
            if (null != _db.GetAll().Where(x => x.CarbrandsID == id).ToList())
            {

                return View(_db.GetAll().Where(x => x.CarbrandsID == id).ToList());
            }
            return View(_db.GetAll().Where(x => x.CarbrandsID == id).ToList());
        }
    }
}
