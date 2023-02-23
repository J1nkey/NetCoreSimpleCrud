using Dapper;
using SimpleEcommerceApp.Data;
using SimpleEcommerceApp.Models.Products;
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

        public async void CreateProduct(AddProductRequestDto product)
        {
            // preparing query to executing
            string query = $"INSERT INTO {TableName} (ProductName, Description, Details, Price, IsActive) VALUES (";

            var parameters = new DynamicParameters();

            // vaidate data before add them to query
            if (string.IsNullOrEmpty(product.ProductName))
            {
                // adding error log here
                return;
            }

            query = query + "@ProductName, @Description, @Details ";
            parameters.Add("ProductName", product.ProductName, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("Details", product.Details, DbType.String);


            if (product.Price < 0)
            {
                // adding error log here
                return;
            }

            query = query + ", @Price, @IsActive)";
            parameters.Add("Price", product.Price, DbType.Decimal);
            parameters.Add("IsActive", true, DbType.Boolean);

            using (var connection = _dapperContext.CreateConnection())
            {
                // Executing the query
                int rowsAffect = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void CreateProduct(string productName, string? description, string? details, decimal price)
        {
            // preparing query for executing
            string query = $"INSERT INTO {TableName} ";

            // creating DynamicParameters for binding data to query
            var parameters = new DynamicParameters();

            // validate data before add them to query
            if (string.IsNullOrEmpty(productName))
            {
                // we can add log here
                return;
            }
            query = query + "(ProductName, Description, Details";

            parameters.Add("ProductName", productName, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("Details", details, DbType.String);

            if (price < 0)
            {
                // we can add log here
                return;
            }
            parameters.Add("Price", price, DbType.Decimal);

            query = query + ", price) VALUES (@ProductName, @Description, @Detail, @Price)";


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsPaging(string productName, int pageIndex, int pageSize)
        {
            string procedureName = "GetProductsByNamePaging";
            IEnumerable<Product> products = null;


            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();

                products = await connection.QueryAsync<Product>(
                    procedureName,
                    new
                    {
                        productName = productName,
                        pageIndex = pageIndex,
                        pageSize = pageSize
                    },
                    commandType: CommandType.StoredProcedure);
            }
            return products;
        }

        public int RemoveProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(UpdateProductRequestDto request)
        {
            throw new NotImplementedException();
        }

        public int UpdateProductById(int id, UpdateProductRequestDto request)
        {
            // Checking product is existing

            throw new NotImplementedException();
        }
    }
}
