using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using eCommercePro.Models.ViewData;
using eCommercePro.Models.Enum;
using eCommercePro.Models.DAL;

namespace eCommercePro.Models.Method
{
	public static class CardBasket
	{			
		

		public static bool AddProduct(int productId, int quantity, int type)
		{
			ETicaretEntities _db = new ETicaretEntities();
			List<CartLine> _cardLines = (List<CartLine>)HttpContext.Current.Cache["Sepet"] ?? new List<CartLine>();
					
			var line = _cardLines.FirstOrDefault(i => i.ProductId == productId);
			if (line == null)
			{
				var product = _db.Product.Where(w => w.id == productId).FirstOrDefault();
				var ctx = HttpContext.Current.GetOwinContext();
				ClaimsPrincipal user = ctx.Authentication.User;
				var identity = (ClaimsIdentity)user.Identity;
				int userID = 0;
				if (identity.IsAuthenticated)
				{
					userID = Convert.ToInt32(identity.FindFirst(ClaimTypes.Sid).Value);
				}
				CartLine newline = new CartLine();
				newline.Image = product.image;
				newline.TotalPrice = product.Price * quantity;
				newline.ProductId = product.id;
				newline.Quantity = quantity;
				newline.UserId = userID;
				newline.Price = product.Price;
				newline.Marka = product.Brand_Model.Brand.brandName;
				newline.Model = product.Brand_Model.Model.modelName;
				_cardLines.Add(newline);
				HttpContext.Current.Cache["Sepet"] = _cardLines;

			}
			else
			{
				CartLine newData = line;
				if (type == (int)EnumHelper.SepetEklemeTip.yeni_ekle)
				{
					newData.Quantity = newData.Quantity + quantity;
					newData.TotalPrice = newData.Price * newData.Quantity;
				}
				else
				{
					newData.Quantity = quantity;
					newData.TotalPrice = newData.Price * newData.Quantity;
				}
				List<CartLine> newList = new List<CartLine>();
				foreach (var item in _cardLines)
				{
					if (item.ProductId == line.ProductId)
					{
						item.Quantity = newData.Quantity;
						item.TotalPrice = newData.TotalPrice;
					}
					newList.Add(item);
				}							
				HttpContext.Current.Cache["Sepet"] = newList;
			}
			return true;
		}

		public static bool DeleteProduct(int productId)
		{
			var listData = (List<CartLine>)HttpContext.Current.Cache["Sepet"];
			var data = listData.Where(w => w.ProductId == productId).FirstOrDefault();
			if (data != null)
			{
				listData.Remove(data);
				HttpContext.Current.Cache["Sepet"] = listData;
			}
			return true;
		}
		
	}
}



