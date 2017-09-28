﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public JsonResult Index(Profil profil)
        {
            //Note : you can bind same list from database
           List<Profil> ObjList = _profilService.ObtientTousLesProfils();
            //Searching records from list using LINQ query
            var profilName = (from N in ObjList
                              where N.NomProfil.ToLower().StartsWith(profil.NomProfil.ToLower())
                              select new { N.NomProfil });
            //var profilName = (from N in ObjList
            //                where N.NomProfil.Contains(Prefix)
            //                select new { N.NomProfil });
            return Json(profilName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutoCompletion(string saisie)
        {
            //Note : you can bind same list from database
            List<Profil> ObjList = _profilService.ObtientTousLesProfils();
            //Searching records from list using LINQ query
            var profilName = (from N in ObjList
                              where N.NomProfil.ToLower().StartsWith(saisie.ToLower())
                              select new { N.NomProfil });
            //var profilName = (from N in ObjList
            //                where N.NomProfil.Contains(Prefix)
            //                select new { N.NomProfil });
            return Json(profilName, JsonRequestBehavior.AllowGet);
        }

    }
}