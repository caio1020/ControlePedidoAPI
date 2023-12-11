using ControlePedidos.Model;

namespace ControlePedidos.Interfaces.Services
{
    public interface IClientService
    {
        List<ClientModel> GetAll();
        ClientModel GetById(int id);
        void Insert(InsertClientModel request);
        void Update(ClientModel client);
        void Delete(int id);
    }
}
