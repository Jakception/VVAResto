using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Allergie
    {
        [Key]
        public string CodeAllergie { get; set; }
        [Required]
        public string NomAllergie { get; set; }
    }
}