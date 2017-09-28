using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Menu
    {
        [Key]
        [Column(Order = 1)]
        public string CodeTM { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime DateMenu { get; set; }
        [Required]
        public string NomMenu { get; set; }
        public string CommentaireMenu { get; set; }
        public DateTime HrOuverture { get; set; }
    }
}