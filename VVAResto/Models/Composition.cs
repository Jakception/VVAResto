using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Composition
    {
        [Key]
        [Column(Order = 1)]
        public string CodeTP { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CodeTM { get; set; }
    }
}