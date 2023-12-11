using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ControlePedidos.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DKP");

            _dbConnection = new SqlConnection(connectionString);
        }     

        public List<Order> GetAll()
        {
            string storedProcedure = "PR_ORDER_GETALL";
            return _dbConnection.Query<Order>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();
        }

        public Order GetById(int id)
        {
            string storedProcedure = "PR_ORDER_GET_BY_ID";
            var parameters = new { Id = id };
            return _dbConnection.QueryFirstOrDefault<Order>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Update(Order order)
        {
            string storedProcedure = "PR_ORDER_UPDATE";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", order.Id);
            parameters.Add("@ClientId", order.ClientId);
            parameters.Add("@Value", order.ValueOrder);
            parameters.Add("@ProductId", order.ProductId);

            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            string storedProcedure = "PR_ORDER_DELETE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Insert(Order order)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ClientId", order.ClientId);
            parameters.Add("@Value", order.ValueOrder);
            parameters.Add("@ProductId", order.ProductId);

            string storedProcedure = "PR_ORDER_INSERT";
           
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
