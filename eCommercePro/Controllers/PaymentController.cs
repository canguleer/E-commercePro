using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommercePro.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Payment_Detail()
        {
            return View();
        }

		public ActionResult _Shopping_Card()
		{
			return PartialView();
		}
		public ActionResult _Methods()
		{
			return PartialView();
		}
		public ActionResult _Delivery()
		{
			return PartialView();
		}
		public ActionResult _Confirmation()
		{
			return PartialView();
		}
	}
}