using IntroductionEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroductionEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Cegep c = new Cegep();
            var trieProf = c.Profs.Take(2).OrderBy(p => p.nom).ToList();
            //cegep.SaveChanges();

            return this.Content("ok");
        }
    }
}