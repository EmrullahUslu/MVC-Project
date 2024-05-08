using EPayCarAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPayCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        [HttpPost("OdemeYap")]
        public bool Pay(Payment p)
        {
            return true;
        }
    }
}

