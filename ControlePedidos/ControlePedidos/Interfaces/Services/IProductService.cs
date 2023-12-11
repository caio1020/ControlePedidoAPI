using ControlePedidos.Model;

namespace ControlePedidos.Interfaces.Services
{
    public interface IProductService
    {
        List<ProductModel> GetAll();
        ProductModel GetById(int id);
        void Insert(InsertProductModel product);
        void Update(ProductModel product);
        void Delete(int id);
    }
}
