using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Plat
    {
        [Key]
        public int NoPlat { get; set; }
        [Required]
        public string NomPlat { get; set; }
        public string DescriptionPlat { get; set; }
        public bool Quotidien { get; set; }
        public string MotCle1 { get; set; }
        public string MotCle2 { get; set; }
        public string MotCle3 { get; set; }
        public virtual TypePlat TypePlat{ get; set; }
    }
}