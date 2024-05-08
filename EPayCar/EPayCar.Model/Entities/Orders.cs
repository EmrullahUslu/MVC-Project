using EPayCar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPayCar.Model.Entities
{
    public class Orders : CoreEntity
    {

        public string AdSoyad { get; set; }

        public int Ay { get; set; }

        public int Year { get; set; }

    }
}
