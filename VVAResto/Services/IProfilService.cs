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
        List<Profil> ObtientTousLesProfilsVacanciers();
        List<Profil> ObtientLesProfilsParLeNom(string nom);
        string AjouterProfil(string nom, string prenom);
        void ModifierProfil(string identifiant, DateTime dateDebutSejour, DateTime dateDFinSejour, bool profilResto);
        Profil Authentifier(string identifiant, string motDePasse);
        Profil ObtenirProfil(string id);
    }
}
