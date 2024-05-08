using EPayCar.Core.Entity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPayCar.Model.Entities
{
    public class Carbrands : CoreEntity
    {
        public string Brand { get; set; }

        public string Description { get; set; }

        public ICollection<Carscs> carscs { get; set; }
    }
}
