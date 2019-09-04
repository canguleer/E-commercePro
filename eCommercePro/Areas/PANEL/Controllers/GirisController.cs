using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommercePro.Areas.PANEL.Controllers
{
	[Authorize(Roles = "admin")]
    public class GirisController : Controller
    {
        // GET: PANEL/Giris
        public ActionResult Index()
        {
            return View();
        }
    }
}