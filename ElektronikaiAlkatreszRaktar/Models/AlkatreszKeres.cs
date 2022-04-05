using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszRaktar.Models
{
    public class AlkatreszKeres
    {
        public String Megnevezes { get; set; }
        public String Gyarto { get; set; }
        public String Tipus { get; set; }
        public double Beszerzes { get; set; }
        public SelectList Megnevezesek { get; set; }
        public SelectList Tipusok { get; set; }
        public List<Alkatresz> Alkatreszek { get; set; }
    }
}
