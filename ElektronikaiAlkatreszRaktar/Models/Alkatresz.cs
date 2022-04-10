using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Megnevezés")]
        [StringLength(60)]
        public String Megnevezes { get; set; }

        [Display(Name = "Gyártó")]
        [StringLength(30)]
        public String Gyarto { get; set; }

        [Display(Name = "Típus")]
        [StringLength(30)]
        public String Tipus { get; set; }

        [Display(Name = "Beszerzési Ár")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Beszerzes { get; set; }
    }
}
