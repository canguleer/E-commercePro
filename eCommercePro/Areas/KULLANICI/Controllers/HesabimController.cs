using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommercePro.Areas.KULLANICI.Controllers
{
	[Authorize(Roles = "musteri")]
	public class HesabimController : Controller
    {
        // GET: KULLANICI/Hesabim
        public ActionResult Index()
        {
            return View();
        }
    }
}