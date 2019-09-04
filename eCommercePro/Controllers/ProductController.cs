using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eCommercePro.Models.Interface;
using eCommercePro.Models.Method;
using eCommercePro.Models.ViewData;

namespace eCommercePro.Controllers
{
	public class ProductController : Controller
	{
		I_Products _prd;
		public ProductController(I_Products prd)
		{
			_prd = prd;
		}


		public async Task<ActionResult> Products(int id)
		{
			var liste = await _prd.Urunler(id);
			var brands = await _prd.GetBrands(id);
			var models = await _prd.GetCategoryModels(id);
			var categories = await _prd.GetCategories();
			ViewBag.Brands = brands;
			ViewBag.Models = models;
			ViewBag.Categories = categories;
			return View(liste);
		}

		public async Task<ActionResult> Product_Detail(int id)
		{
			ViewBag.Categories = await _prd.GetCategories();
			ViewBag.Brands = await _prd.GetBrands(id);
			var urun = await _prd.Urun_Detay(id);
			return View(urun);

		}

		public JsonResult AddCardProduct(int productId, int quantity, int type)
		{
			bool sonuc = CardBasket.AddProduct(productId, quantity, type);
			return Json(sonuc, JsonRequestBehavior.AllowGet);
		}

		public JsonResult DeleteCardProduct(int productId)
		{
			bool sonuc = CardBasket.DeleteProduct(productId);
			return Json(sonuc, JsonRequestBehavior.AllowGet);
		}

		public ActionResult _GetCartList()
		{
			var list = (List<CartLine>)HttpContext.Cache["Sepet"];
			return PartialView("_CardDetail", list);
		}

		public ActionResult Shopping_Card()
		{			
			return View(); 

		} 
		




	}






}