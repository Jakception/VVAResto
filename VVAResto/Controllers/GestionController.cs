using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VVAResto.Models;
using VVAResto.Services;

namespace VVAResto.Controllers
{
    public class GestionController : Controller
    {
        private IProfilService _profilService;

        public GestionController() : this(new ProfilService())
        {

        }

        private GestionController(IProfilService profilIoc)
        {
            _profilService = profilIoc;
        }

        // GET: Gestion
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(Profil profil)
        //{
        //    List<Profil> ListeDesProfils = _profilService.ObtientLesProfilsParLeNom(profil.NomProfil);
        //    return View(ListeDesProfils);
        //}

        [HttpPost]
        public JsonResult AutoCompletion(string saisie)
        {
            //Note : you can bind same list from database
            List<Profil> ObjList = _profilService.ObtientTousLesProfilsVacanciers();
            //List<Profil> ObjList = _profilService.ObtientTousLesProfils();
            //Searching records from list using LINQ query
            //var profilName = (from N in ObjList
            //                  where N.NomProfil.ToLower().StartsWith(saisie.ToLower())
            //                  select new { N.NomProfil });
            var profilName = (from N in ObjList
                              where N.NomProfil.ToLower().Contains(saisie.ToLower())
                              select new { N.NomProfil });
            return Json(profilName, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AfficheRechercheProfil(Profil profil)
        {
            List<Profil> ListeDesProfils = new List<Profil>();

            if (profil != null)
            {
                if (!string.IsNullOrWhiteSpace(profil.NomProfil))
                    ListeDesProfils = _profilService.ObtientLesProfilsParLeNom(profil.NomProfil);
                    Thread.Sleep(500);
                
            }
            return PartialView(ListeDesProfils);
        }

        public ActionResult AjouterProfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterProfil(Profil profil)
        {
            return View();
        }

        public ActionResult ModifierProfil(string identifiant)
        {
            Profil profil = _profilService.ObtenirProfil(identifiant);
            return View(profil);
        }

        [HttpPost]
        public ActionResult ModifierProfil(Profil profil)
        {
            return View();
        }
    }
}