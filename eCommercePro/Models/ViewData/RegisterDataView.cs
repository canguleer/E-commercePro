using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommercePro.Models.ViewData
{
	public class RegisterDataView:IDisposable
	{
		public string kullaniciadi { get; set; }
		public string sifre { get; set; }
		public string adi { get; set; }
		public string soyadi { get; set; }
		public string eposta { get; set; }
		public string telefon { get; set; }
		public string tarih { get; set; }

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}