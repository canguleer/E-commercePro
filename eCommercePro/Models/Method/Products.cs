using System;
using System.Collections.Generic;
using System.Linq;
using eCommercePro.Models.Interface;
using System.Data.Entity;
using System.Threading.Tasks;
using eCommercePro.Models.DAL;
using eCommercePro.Models.Enum;

namespace eCommercePro.Method
{
    public class Products : I_Products
    {
        private ETicaretEntities _db;
        public Products(ETicaretEntities db)
        {
            _db = db;
        }
        public async Task<List<Product>> Urunler(int categoriId)
        {
            var list = await _db.Product.OrderByDescending(i => i.id).Where(w => w.Brand_Model.Brand.category_id == categoriId && w.status > 0).ToListAsync();
            return list;
        }

        public async Task<List<Brand>> GetBrands(int categoryId)
        {
            var list = await _db.Brand.Where(w => w.category_id == categoryId).OrderBy(w => w.brandName).Where(w => w.status > 0).ToListAsync();
            return list;
        }

        public async Task<List<Model>> GetCategoryModels(int categoryId)
        {
            var list = await _db.Model.Where(q => q.Brand_Model.Any(r => r.Brand.category_id == categoryId)).OrderBy(w => w.modelName).Where(w => w.status > 0).ToListAsync();
            return list;
        }

        public async Task<List<Model>> GetAllModels()
        {
            var list = await _db.Model.Where(q => q.status == (int)EnumHelper.Status.aktif).OrderBy(w => w.modelName).ToListAsync();
            return list;
        }

        public async Task<Product> Urun_Detay(int productId)
        {
            var urun = await _db.Product.Where(w => w.id == productId).FirstOrDefaultAsync();
            return urun;
        }

        public async Task<List<Category>> GetCategories()
        {
            var list = await _db.Category.Where(w => w.status > 0).ToListAsync();
            return list;
        }

        public async Task<int> ProductCategoryCount(int categoriId)
        {
            int count = await _db.Product.Where(w => w.Brand_Model.Brand.category_id == categoriId).CountAsync();
            return count;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var list = await _db.Product.OrderByDescending(i => i.id).Where(w => w.status > 0).ToListAsync();
            return  list;
        }

        
    }
}


