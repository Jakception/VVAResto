using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VVAResto.Models;
using VVAResto.Services;
using VVAResto.ViewModels;

namespace VVAResto.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IProfilService _profilService;

        public LoginController() : this(new ProfilService())
        {

        }

        private LoginController(IProfilService profilIoc)
        {
            _profilService = profilIoc;
        }

        public ActionResult Index()
        {
            ProfilViewModel viewModel = new ProfilViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Profil = _profilService.ObtenirProfil(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ProfilViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Profil utilisateur = _profilService.Authentifier(viewModel.Profil.Identifiant, viewModel.Profil.Mdp);
                if (utilisateur != null)
                {
                    FormsAuthentication.SetAuthCookie(utilisateur.Identifiant, false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Profil.Identifiant", "Prénom et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}