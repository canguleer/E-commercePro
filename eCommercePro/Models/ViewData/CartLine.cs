using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommercePro.Models.ViewData
{
	public class CartLine
	{		
		public string Marka { get; set; }
		public string Model { get; set; }
		public string Urun { get; set; }
		public int UserId { get; set; }
		public int ProductId { get; set; }
		public string Image { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
	}
}