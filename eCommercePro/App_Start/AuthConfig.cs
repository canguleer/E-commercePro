using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(eCommercePro.App_Start.AuthConfig))]

namespace eCommercePro.App_Start
{
	public class AuthConfig
	{
		public void Configuration(IAppBuilder app) {
			AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
				CookieSecure = CookieSecureOption.SameAsRequest,
				CookieName = "eCommercePro"
			});
		}

	}
}