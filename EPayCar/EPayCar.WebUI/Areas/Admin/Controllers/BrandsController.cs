using EPayCar.Core.Service;
using EPayCar.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPayCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IDbService<Carbrands> _db;

        public BrandsController(IDbService<Carbrands> db)
        {
            _db = db;
        }

        public IActionResult Index() => View(_db.GetAll());


        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Carbrands c)
        {
            if (c.Brand != null && c.Description != null)
            {
                return _db.Add(c) ? RedirectToAction("Index") : View();
            }

            ViewBag.BrandsAddError = "Marka Eklerken bütün verileri giriniz";
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_db.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Carbrands c)
        {
            if (c.Brand != null && c.Description != null)
            {
                return _db.Update(c) ? RedirectToAction("Index") : View();
            }

            ViewBag.BrandsUpdateError = "Marka güncellemek için bütün değerleri giriniz";
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return _db.Delete(_db.GetById(id)) ? RedirectToAction("Index") : View();
            }
            return View();
        }

    }
}
