using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using eCommercePro.Models.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity;
using eCommercePro.Models.DAL;

namespace eCommercePro.Models.Method
{
	public class Helper : I_Helper
	{
		private ETicaretEntities _db;
		public Helper(ETicaretEntities db)
		{
			_db = db;
		}
		public List<Claim> GetClaims(User data)
		{
			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, data.userName));
			claims.Add(new Claim(ClaimTypes.Sid, data.id.ToString()));
			claims.Add(new Claim(ClaimTypes.Role, data.Role.role1));
			if (data.Role.role1 == "musteri")
			{
				claims.Add(new Claim(ClaimTypes.Name, data.Customer.Select(w => w.name).FirstOrDefault()));
				claims.Add(new Claim(ClaimTypes.Surname, data.Customer.Select(w => w.lastName).FirstOrDefault()));
				claims.Add(new Claim(ClaimTypes.MobilePhone, data.Customer.Select(w => w.phone).FirstOrDefault()));
				claims.Add(new Claim(ClaimTypes.Email, data.Customer.Select(w => w.eposta).FirstOrDefault()));
			}

			return claims;
		}

		public void SignIn(List<Claim> claims)
		{
			ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, claimIdentity);
			HttpContext.Current.User = new ClaimsPrincipal(AuthenticationManager.AuthenticationResponseGrant.Principal);
		}

		

		public IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.Current.GetOwinContext().Authentication;
			}
		}
		
	}
}