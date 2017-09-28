using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Indication
    {
        [Key]
        [Column(Order = 1)]
        public int NoPlat { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CodeAllergie { get; set; }
    }
}