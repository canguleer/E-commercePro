using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using eCommercePro.Models.DAL;
using eCommercePro.Models.Interface;
using eCommercePro.Models.ViewData;

namespace eCommercePro.Controllers
{
	public class HomeController : Controller
	{
		I_Products _prd;
        ETicaretEntities _db;
		public HomeController(I_Products prd, ETicaretEntities db)
		{
			_prd = prd;
            _db = db;
		}

		

		// GET: Home
		public async Task<ActionResult> Index()
		{
			ViewBag.Models = await _prd.GetAllModels();
			var data = await _prd.GetAllProduct();
			return View(data);
		}


		public ActionResult About()
		{
			return View();
		}

		public ActionResult _UstSepetList()
		{
			var sepet = (List<CartLine>)HttpContext.Cache["Sepet"] ?? new List<CartLine>();
			return PartialView("_UstSepet", sepet);

		}

        public ActionResult _UrunYorumGetir(int id)
        {
            var data = _db.Product_Comments.Where(e => e.product_id == id && e.status == 1).ToList();
            return PartialView("_UrunYorumlar", data);
        }
		
		public ActionResult Detail()
		{
			return View();
		}
		public ActionResult Checkout()
		{
			return View();
		}
		public ActionResult Error404()
		{
			return View();
		}
		public ActionResult Contact()
		{
			return View();

		}
		public ActionResult Product3()
		{
			return View();
		}

		public ActionResult Product4()
		{
			return View();
		}

		public ActionResult Blog()
		{
			return View();
		}
		public ActionResult BlogDetail()
		{
			return View();
		}





	}
}