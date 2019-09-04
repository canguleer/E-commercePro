using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using eCommercePro.Models.DAL;
using eCommercePro.Models.Enum;
using eCommercePro.Models.Interface;
using eCommercePro.Models.ViewData;

namespace eCommercePro.Controllers
{
	public class AccountController : Controller
	{
		private ETicaretEntities _db;
		I_Helper _hlp;

		public AccountController(ETicaretEntities db, I_Helper hlp)
		{
			_db = db;
			_hlp = hlp;
		}
		

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]

		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterDataView detail)
		{
			var kontrol = _db.Customer.Where(e => (e.name == detail.adi && e.lastName == detail.soyadi) || e.eposta == detail.eposta).FirstOrDefault();
			if (kontrol != null)
			{
				Session.Add("mesaj", "Daha önceden müşteri kaydınız bulunmaktadır. Lütfen hatırlatma kısmından kullanıcı adı  ve şifre bilginizi öğreniniz");
				return RedirectToAction("Login", "Account");
			}
			else
			{

			using (TransactionScope scp = new TransactionScope())
			{
				try
				{
					User user = new User();
					user.userName = detail.kullaniciadi;
					user.password = detail.sifre;
					user.date = DateTime.Now;
					user.role_id = (int)EnumHelper.Rol.musteri;
					user.status = (int)EnumHelper.Status.aktif;

					Customer customer = new Customer();
					customer.name = detail.adi;
					customer.lastName = detail.soyadi;
					customer.eposta = detail.eposta;
					customer.phone = detail.telefon;
					customer.status = (int)EnumHelper.Status.aktif;
					user.Customer.Add(customer);
					_db.User.Add(user);
					_db.SaveChanges();
					scp.Complete();
				}
				catch
				{
					return RedirectToAction("Login", "Account");
				}
				finally {
					scp.Dispose();
				}
			}
			}
			return RedirectToAction("Index", "Hesabim", new { area = "KULLANICI"});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(string kullaniciAdi, string sifre, string returnUrl)
		{
			var kontrol = _db.User.Where(w => w.userName == kullaniciAdi && w.password == sifre).FirstOrDefault();
			if (kontrol != null)
			{
				List<Claim> claims = _hlp.GetClaims(kontrol);
				if (claims != null)
				{
					_hlp.SignIn(claims);
					var identity = (ClaimsIdentity)User.Identity;
					string rolu = identity.Claims.Where(w => w.Type == ClaimTypes.Role).Select(q => q.Value).FirstOrDefault();
					switch (rolu)
					{
						case "admin":
							returnUrl = "../PANEL/Giris";
							break;
						case "musteri":
							returnUrl = "../KULLANICI/Hesabim";
							break;
						default:
							break;
					}
				}
				return RedirectToAction(returnUrl);
			}
			return View();
		}


	}
}