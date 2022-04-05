using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszRaktar.Models
{
    public class Alkatresz
    {
        public Alkatresz()
        {
        }

        public int Id { get; set; }
        public String Megnevezes { get; set; }
        public String Gyarto { get; set; }
        public String Tipus { get; set; }
        public double Beszerzes { get; set; }
    }
}
