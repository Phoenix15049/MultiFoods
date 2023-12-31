using MultiFoods_Backend.Models;

namespace MultiFoods_Backend.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IDbService _dbService;

        public ProductsService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateProduct(Products product)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.Products (product_id,product_name, product_price) VALUES (@product_id, @product_name, @product_price)",
                    product);
            return true;
        }

        public async Task<List<Products>> GetProductList()
        {
            var ProductList = await _dbService.GetAll<Products>("SELECT * FROM public.Products", new { });
            return ProductList;
        }


        public async Task<Products> GetProduct(int id)
        {
            var ProductList = await _dbService.GetAsync<Products>("SELECT * FROM public.Products where product_id=@product_id", new { id });
            return ProductList;
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            var updateProduct =
                await _dbService.EditData(
                    "Update public.Products SET product_name=@product_name, product_price=@product_price WHERE id=@id",
                    product);
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var deleteProduct = await _dbService.EditData("DELETE FROM public.Products WHERE id=@Id", new { id });
            return true;
        }
    }
}
