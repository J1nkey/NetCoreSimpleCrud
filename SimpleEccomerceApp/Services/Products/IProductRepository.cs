using SimpleEcommerceApp.Models;

namespace SimpleEcommerceApp.Services.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsPaging(string productName, int pageIndex, int pageSize);
        void CreateProduct(Product product);
        void CreateProduct(string productName, string? description, string? detail, decimal price);
    }
}
