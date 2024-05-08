using EPayCar.Core.Service;
using EPayCar.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPayCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IDbService<Orders> _dbOrders;

        public OrdersController(IDbService<Orders> db)
        {
            _dbOrders = db;
        }
        public IActionResult Index()
        {
            return View(_dbOrders.GetAll());
        }

        public IActionResult Wasdelivered(int id)
        {
            if (id > 0)
            {
                return _dbOrders.Delete(_dbOrders.GetById(id)) ? RedirectToAction("Index") : View();
            }

            return View();
        }
    }
}
