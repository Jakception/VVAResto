using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class TypePlat
    {
        [Key]
        public string CodeTP { get; set; }
        [Required]
        public string NomTP { get; set; }
    }
}