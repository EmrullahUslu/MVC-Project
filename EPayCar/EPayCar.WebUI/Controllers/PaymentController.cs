using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using EPayCar.Dto;
using EPayCar.Core.Service;
using EPayCar.Model.Entities;
using EPayCar.WebUI.Models;

namespace EPayCar.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IDbService<Orders> _db, _CartItems;

        public PaymentController(IDbService<Orders> db)
        {
            _db = db;
        }

      

        public async Task<IActionResult> Pay(SanalPos c)
        {
            if (c != null)
            {


                var sp = new SanalPos()
                {
                    AdSoyad = c.AdSoyad,
                    KartNo = c.KartNo,
                    Cvv = c.Cvv,
                    Ay = c.Ay,
                    Yil = c.Yil,
                    Tutar = c.Tutar
                };

                var jsonData = JsonConvert.SerializeObject(sp); 

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json"); 

                using (var client = new HttpClient())
                {
                    var result = await client.PostAsync("https://localhost:7248/api/Pay/OdemeYap", content);

                    if (result.IsSuccessStatusCode)
                    {
                        var a = Convert.ToBoolean(await result.Content.ReadAsStringAsync());
                        if (a)
                        {
                            try
                            {
                                ClearCart();
                                OrdersSave(c);
                                return View("SuccessPay");
                            }
                            catch
                            {
                                return View();
                            }
                        }
                        else
                        {

                            return View();
                        }
                    }
                }

                return View();

            }
            return View();
        }




        public IActionResult SuccessPay()
        {
            return View();
        }

        void ClearCart()
        {
            HttpContext.Session.Clear();
        }


        void  OrdersSave(SanalPos c)
        {
                    var Order = new Orders()
                    {
                        AdSoyad = c.AdSoyad,
                        Ay = c.Ay,
                        Year = c.Yil,
                    };
                _db.Add(Order);
        }

    }
}
