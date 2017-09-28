using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VVAResto.Models;

namespace VVAResto.ViewModels
{
    public class ProfilViewModel
    {
        public Profil Profil { get; set; }
        public bool Authentifie { get; set; }
    }
}