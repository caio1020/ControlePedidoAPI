using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;

namespace ControlePedidos.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Delete(int id)
        {
            var user = _productRepository.GetById(id);

            if (user == null)
                throw new Exception("Usuario não encontrado");

            _productRepository.Delete(id);

        }

        public List<ProductModel> GetAll()
        {
            List<Product> products = new List<Product>();

            products = _productRepository.GetAll();

            var response = MapProductList(products);

            return response;
        }

        public ProductModel GetById(int id)
        {
            var product = _productRepository.GetById(id);

            var response = MapProduct(product);

            return response;
        }

        public void Insert(InsertProductModel request)
        {
            Product product = new Product
            {
                ProductName = request.ProductName,
                ProductValue = request.ProductValue,
                Amount = request.Amount
            };

            _productRepository.Insert(product);
        }

        public void Update(ProductModel product)
        {
            // Obter o produto existente pelo ID
            var existingProduct = _productRepository.GetById(product.Id);

            // Verificar se o produto existe
            if (existingProduct != null)
            {
                // Atualizar apenas os campos que estão preenchidos no modelo de atualização
                if (!string.IsNullOrEmpty(product.ProductName))
                {
                    existingProduct.ProductName = product.ProductName;
                }

                if (product.ProductValue != 0)
                {
                    existingProduct.ProductValue = product.ProductValue;
                }

                if (product.Amount != 0)
                {
                    existingProduct.Amount = product.Amount;
                }

                // Chamar o método de atualização no repositório
                _productRepository.Update(existingProduct);
            }
            else
            {
                throw new Exception($"Produto com ID {product.Id} não encontrado.");
            }
        }


        private ProductModel MapProduct(Product product)
        {

            var productModel = new ProductModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductValue = product.ProductValue,
                Amount = product.Amount
            };

            return productModel;

        }
        private List<ProductModel> MapProductList(List<Product> list)
        {

            List<ProductModel> response = new List<ProductModel>();

            foreach (var item in list)
            {
                var productModel = new ProductModel
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    ProductValue = item.ProductValue,
                    Amount = item.Amount
                };

                response.Add(productModel);
            }

            return response;

        }
    }
}
