﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using VVAResto.Models;

namespace VVAResto.Services
{
    public class ProfilService : IProfilService
    {
        private BddContext bdd;

        public ProfilService()
        {
            bdd = new BddContext();
        }

        public List<Profil> ObtientTousLesProfils()
        {
            return bdd.Profils.ToList();
        }

        public string AjouterProfil(string nom, string prenom)
        {
            string motDePasseEncode = "123";
                //EncodeMD5(GenerateMdp());
            Profil utilisateur = new Profil {
                Identifiant = GenerateIdentifiant(nom, prenom),
                Mdp = motDePasseEncode,
                NomProfil = nom,
                PrenomProfil = prenom,
                DateInscrip = DateTime.Now,
                DateDebutSejour = DateTime.Now,
                DateFinSejour = DateTime.Now,
                TypeProfil = "Vacancier",
                ProfilResto = false,
                DateFermeture = DateTime.Now
            };
            bdd.Profils.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.Identifiant;
        }

        public string ValiderProfil(string identifiant, DateTime dateDebutSejour, DateTime dateDFinSejour, bool profilResto)
        {
            throw new NotImplementedException();
        }

        public Profil Authentifier(string identifiant, string motDePasse)
        {
            // string motDePasseEncode = EncodeMD5(motDePasse);
            // return bdd.Profils.FirstOrDefault(u => u.Identifiant == identifiant && u.Mdp == motDePasseEncode);
            return bdd.Profils.FirstOrDefault(u => u.Identifiant == identifiant && u.Mdp == motDePasse);
        }

        public Profil ObtenirProfil(string id)
        {
            return bdd.Profils.FirstOrDefault(u => u.Identifiant == id);
        }


        public void Dispose()
        {
            bdd.Dispose();
        }

        private string GenerateIdentifiant(string nom, string prenom)
        {
            string identifiant;

            identifiant = nom.Substring(0, 5) + prenom.Substring(0, 2);

            return identifiant; 
        }

        private string GenerateMdp()
        {
            string mdp = "";

            List<string> listeLettre = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };
            List<string> listeChiffre = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random rand = new Random();

            int taille = rand.Next(5, 9);

            int loc;
            int index;

            int tailleListeLettre = listeLettre.Count;
            int tailleListeChiffre = listeChiffre.Count;

            for (int i = 0; i < taille; i++)
            {
                loc = rand.Next(0, 2);
                if (loc == 0)
                {
                    index = rand.Next(0, tailleListeLettre);
                    mdp = mdp + listeLettre[index];
                }
                else
                {
                    index = rand.Next(0, tailleListeChiffre);
                    mdp = mdp + listeChiffre[index];
                }
            }

            return mdp;
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "VVAResto" + motDePasse + "SecurityMDP";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}