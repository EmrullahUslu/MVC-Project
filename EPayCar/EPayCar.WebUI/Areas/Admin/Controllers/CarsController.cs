using EPayCar.Core.Service;
using EPayCar.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPayCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly IDbService<Carscs> _dbCars;
        private readonly IDbService<Carbrands> _dbBrands;

        public CarsController(IDbService<Carscs> dbCar, IDbService<Carbrands> dbBrand)
        {
            _dbCars = dbCar;
            _dbBrands = dbBrand;
        }
        public IActionResult Index()
        {
            return View(_dbCars.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.ArabaListesi = _dbBrands.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Carscs p, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);


                    p.CarImageName = filename;
                    return _dbCars.Add(p) ? RedirectToAction("Index") : View();
                }

            }


            ViewBag.ArabaAddError = "Bütün alanları eksiksiz doldurmalısınız";
            return View();
        }

        public IActionResult Update(int id)
        {
            ViewBag.MarkaListesi = _dbBrands.GetAll();
            return View(_dbCars.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Carscs p, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                p.CarImageName = filename;
                return _dbCars.Update(p) ? RedirectToAction("Index") : View();
            }

            ViewBag.ArabaUpdateError = "Bütün alanları eksiksiz doldurmalısınız";
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return _dbCars.Delete(_dbCars.GetById(id)) ? RedirectToAction("Index") : View();
            }

            return View();
        }
    }
}

