using Dapper;
using SimpleEcommerceApp.Data;
using SimpleEcommerceApp.Models;
using System.Data;

namespace SimpleEcommerceApp.Services.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private const string TableName = "Products";
        public ProductRepository(ApplicationDbContext db,
            ApplicationDapperContext dapperContext) 
            : base(db, dapperContext)
        {
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async void CreateProduct(string productName, string? description, string? details, decimal price)
        {
            // preparing query for executing
            string query = $"INSERT INTO {TableName} ";

            // validate data before add them to query
            if (string.IsNullOrEmpty(productName))
            {
                // we can add log here
                return;
            }

            query = query + "(ProductName, Description, Details";

            if (price < 0)
            {
                // we can add log here
                return;
            }

            query = query + ", price) VALUES (@ProductName, @Description, @Detail, @Price)";

            // Binding parameters to query
            var parameters = new DynamicParameters();
            parameters.Add("ProductName", productName, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("Details", details, DbType.String);
            parameters.Add("Price", price, DbType.Decimal);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public IEnumerable<Product> GetProductsPaging(string productName, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
