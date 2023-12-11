using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ControlePedidos.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClientRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DKP");

            _dbConnection = new SqlConnection(connectionString);
        }     

        public List<Client> GetAll()
        {
            string storedProcedure = "PR_CLIENT_GETALL";
            return _dbConnection.Query<Client>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();
        }

        public Client GetById(int id)
        {
            string storedProcedure = "PR_CLIENT_GET_BY_ID";
            var parameters = new { Id = id };
            return _dbConnection.QueryFirstOrDefault<Client>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Update(Client client)
        {
            string storedProcedure = "PR_CLIENT_UPDATE";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", client.Id);
            parameters.Add("@Name", client.Name);
            parameters.Add("@Email", client.Email);
            parameters.Add("@Contact", client.Contact);

            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            string storedProcedure = "PR_CLIENT_DELETE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Insert(Client client)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", client.Name);
            parameters.Add("@Email", client.Email);
            parameters.Add("@Contact", client.Contact);

            string storedProcedure = "PR_CLIENT_INSERT";
           
            _dbConnection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
