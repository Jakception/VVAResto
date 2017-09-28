using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVAResto.Models;
using VVAResto.Services;

namespace VVAResto.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProfilService _profilService;

        public HomeController() : this(new ProfilService())
        {

        }

        private HomeController(IProfilService profilIoc)
        {
            _profilService = profilIoc;
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}