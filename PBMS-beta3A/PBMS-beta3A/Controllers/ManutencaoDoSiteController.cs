using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;

namespace PBMS_beta3A.Controllers
{
    public class ManutencaoDoSiteController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ManutencaoDoSite model)
        {
            return View();
        }

    }
}
