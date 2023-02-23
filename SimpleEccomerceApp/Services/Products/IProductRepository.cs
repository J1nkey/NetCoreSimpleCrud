using SimpleEcommerceApp.Models.Products;

namespace SimpleEcommerceApp.Services.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsPaging(string productName, int pageIndex, int pageSize);
        void CreateProduct(AddProductRequestDto product);
        void CreateProduct(string productName, string? description, string? detail, decimal price);
        int RemoveProductById(int id);
        int UpdateProductById(int id, UpdateProductRequestDto request);
        int UpdateProduct(UpdateProductRequestDto request);
    }
}
