using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommercePro.Models.DAL;
using eCommercePro.Models.ViewData;

namespace eCommercePro.Controllers
{
    public class CartController : Controller
    {
		//private ETicaretEntities7 db = new ETicaretEntities7();
		// GET: Cart
		public ActionResult Index()
        {
            return View();
        }

	}


}