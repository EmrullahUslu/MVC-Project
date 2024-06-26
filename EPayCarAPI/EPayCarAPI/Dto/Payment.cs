﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EPayCarAPI.Dto
{
    public class Payment
    {
        public string AdSoyad { get; set; }
        public string KartNo { get; set; }
        public int Cvv { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public decimal Tutar { get; set; }
    }
}
