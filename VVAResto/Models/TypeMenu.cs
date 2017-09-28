using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class TypeMenu
    {
        [Key]
        public string CodeTM { get; set; }
        [Required]
        public string NomTM { get; set; }
    }
}