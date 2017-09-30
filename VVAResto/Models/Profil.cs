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
        [Display(Name ="Mot de passe")]
        public string Mdp { get; set; }
        //[Required]
        [Display(Name ="Nom")]
        public string NomProfil { get; set; }
        //[Required]
        [Display(Name ="Prénom")]
        public string PrenomProfil { get; set; }
        [Display(Name ="Date d'inscription")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateInscrip { get; set; }
        [Display(Name ="Date de début du séjour")]
        public DateTime DateDebutSejour { get; set; }
        [Display(Name ="Date de fin du séjour")]
        public DateTime DateFinSejour { get; set; }
        [Display(Name ="Type de profil")]
        public string TypeProfil { get; set; }
        [Display(Name ="Validation")]
        public bool ProfilResto { get; set; }
        [Display(Name ="Date de fermeture du profil")]
        public DateTime DateFermeture { get; set; }
    }
}