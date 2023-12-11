using ControlePedidos.Entity;

namespace ControlePedidos.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Insert(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
