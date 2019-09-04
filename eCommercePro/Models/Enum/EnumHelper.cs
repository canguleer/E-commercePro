using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommercePro.Models.Enum
{
	public class EnumHelper
	{
		public enum Rol
		{
			admin = 2,
			musteri = 3
		}

		public enum Status
		{
			aktif = 1,
			pasif = 0
		}

		public enum SepetEklemeTip
		{
			yeni_ekle = 1,
			sepette_guncelle = 2
		}
	}
}