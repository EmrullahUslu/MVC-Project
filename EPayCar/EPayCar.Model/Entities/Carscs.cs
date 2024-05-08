using EPayCar.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPayCar.Model.Entities
{
    public class Carscs : CoreEntity
    {
        [DisallowNull]
        public string CareName { get; set; }

        [DisallowNull]
        public string Model { get; set; }

        [DisallowNull]
        public string Year { get; set; }

        [DisallowNull]
        public int Kilometer { get; set; }

        [DisallowNull]
        public string FuelType { get; set; }


        public string Colour { get; set; }

        [DisallowNull]
        public decimal Price { get; set; }


        public string Description { get; set; }


        public string CarImageName { get; set; }

        public int Stock { get; set; }

        public int CarbrandsID { get; set; }
        public Carbrands Carbrands { get; set; }
    }
}
