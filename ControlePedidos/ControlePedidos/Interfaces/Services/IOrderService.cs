using ControlePedidos.Model;

namespace ControlePedidos.Interfaces.Services
{
    public interface IOrderService
    {
        List<OrderModel> GetAll();
        OrderModel GetById(int id);
        void Insert(InsertOrderModel product);
        void Update(UpdateOrderModel product);
        void Delete(int id);
    }
}
