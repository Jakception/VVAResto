using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Profil
    {
        [Key]
        [Required]
        public string Identifiant { get; set; }
        [Required]
        public string Mdp { get; set; }
        //[Required]
        public string NomProfil { get; set; }
        //[Required]
        public string PrenomProfil { get; set; }
        public DateTime DateInscrip { get; set; }
        public DateTime DateDebutSejour { get; set; }
        public DateTime DateFinSejour { get; set; }
        public string TypeProfil { get; set; }
        public bool ProfilResto { get; set; }
        public DateTime DateFermeture { get; set; }
    }
}