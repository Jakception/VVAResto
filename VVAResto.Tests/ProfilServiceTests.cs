using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVAResto.Models;
using VVAResto.Services;
using System.Collections.Generic;

namespace VVAResto.Tests
{
    [TestClass]
    public class ProfilServiceTests
    {
        [TestMethod]
        public void AjouterProfil_AvecUnNouvelProfil_ObtientTousLesProfilsRevoitBienLeProfil()
        {
            using (IProfilService _profilService = new ProfilService())
            {
                _profilService.AjouterProfil("TestNom", "TestPrenom");
                List<Profil> profils = _profilService.ObtientTousLesProfils();

                Assert.IsNotNull(profils);
                Assert.AreEqual(1, profils.Count);
                Assert.AreEqual("TestNom", profils[0].NomProfil);
                Assert.AreEqual("TestPrenom", profils[0].PrenomProfil);
            }
        }
    }
}
