using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVAResto.Models;

namespace VVAResto.Services
{
    public interface IProfilService : IDisposable
    {
        List<Profil> ObtientTousLesProfils();
        string AjouterProfil(string nom, string prenom);
        string ValiderProfil(string identifiant, DateTime dateDebutSejour, DateTime dateDFinSejour, bool profilResto);
        Profil Authentifier(string identifiant, string motDePasse);
        Profil ObtenirProfil(string id);
    }
}
