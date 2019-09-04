using eCommercePro.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommercePro.Models.Interface
{
	public interface I_Helper
	{
		List<Claim> GetClaims(User data);

		void SignIn(List<Claim> claims);
	}
}
