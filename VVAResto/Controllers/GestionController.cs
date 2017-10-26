using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                    //Thread.Sleep(100);
                
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
            if (ModelState.IsValid)
            {
                _profilService.AjouterProfil(profil.NomProfil, profil.PrenomProfil, profil.DateDebutSejour, profil.DateFinSejour, profil.ProfilResto);
                return View("Index");
            }
            return View(profil);            
        }

        public ActionResult ModifierProfil(string identifiant)
        {
            if(string.IsNullOrWhiteSpace(identifiant))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = _profilService.ObtenirProfil(identifiant);
            if(profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        [HttpPost]
        public ActionResult ModifierProfil(Profil profil)
        {
            if (ModelState.IsValid)
            {
                _profilService.ModifierProfil(profil.Identifiant, profil.DateDebutSejour, profil.DateFinSejour, profil.ProfilResto);
                return View("Index");
            }
            return View(profil);
        }

        public ActionResult SupprimerProfil(string identifiant)
        {
            if (string.IsNullOrWhiteSpace(identifiant))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = _profilService.ObtenirProfil(identifiant);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        [HttpPost]
        public ActionResult SupprimerProfil(Profil profil)
        {
            if (profil == null)
            {
                return HttpNotFound();
            }
            _profilService.SupprimerProfil(profil.Identifiant);
            return View("Index");
        }
    }
}