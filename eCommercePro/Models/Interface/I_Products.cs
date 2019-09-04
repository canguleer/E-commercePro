using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommercePro.Models.DAL;

namespace eCommercePro.Models.Interface
{
    public interface I_Products
    {
        Task<List<Product>> Urunler(int categoriId);
        Task<Product> Urun_Detay(int PoductId);
        Task<List<Brand>> GetBrands(int categoryId);
        Task<List<Model>> GetCategoryModels(int categoryId);
        Task<List<Model>> GetAllModels();
        Task<List<Category>> GetCategories();
        Task<int> ProductCategoryCount(int categoryId);
        Task<List<Product>> GetAllProduct();
    }




}
