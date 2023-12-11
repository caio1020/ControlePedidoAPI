using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ControlePedidos.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository (IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DKP");

            _dbConnection = new SqlConnection(connectionString);
        }     

        public List<Product> GetAll()
        {
            string storedProcedure = "PR_PRODUCT_GETALL";
            return _dbConnection.Query<Product>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();
        }

        public Product GetById(int id)
        {
            string storedProcedure = "PR_PRODUCT_GET_BY_ID";
            var parameters = new { Id = id };
            return _dbConnection.QueryFirstOrDefault<Product>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Update(Product product)
        {
            string storedProcedure = "PR_PRODUCT_UPDATE";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", product.Id);
            parameters.Add("@Name", product.ProductName);
            parameters.Add("@Value", product.ProductValue);
            parameters.Add("@Amount", product.Amount);

            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            string storedProcedure = "PR_PRODUCT_DELETE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Insert(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", product.ProductName);
            parameters.Add("@Value", product.ProductValue);
            parameters.Add("@Amount", product.Amount);

            string storedProcedure = "PR_PRODUCT_INSERT";
           
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
