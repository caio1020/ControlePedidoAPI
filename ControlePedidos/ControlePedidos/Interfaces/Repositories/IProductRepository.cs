using ControlePedidos.Entity;

namespace ControlePedidos.Interfaces.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
