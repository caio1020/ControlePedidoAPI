using ControlePedidos.Entity;

namespace ControlePedidos.Interfaces.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int id);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
