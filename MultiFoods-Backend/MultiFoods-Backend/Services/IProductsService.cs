using MultiFoods_Backend.Models;

namespace MultiFoods_Backend.Services
{
    public interface IProductsService
    {
        Task<bool> CreateProduct(Products product);
        Task<List<Products>> GetProductList();
        Task<Products> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int key);
    }
}
