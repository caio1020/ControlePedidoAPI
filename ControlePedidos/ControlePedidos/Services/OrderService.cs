using ControlePedidos.Data.Repositories;
using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;
using System.Collections.Generic;

namespace ControlePedidos.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderModel> GetAll()
        {
            List<Order> orders = _orderRepository.GetAll();

            var response = MapOrdersList(orders);

            return response;
        }
        public OrderModel GetById(int id)
        {
            Order order = _orderRepository.GetById(id);

            var response = MapOrder(order);

            return response;
        }      

        public void Insert(InsertOrderModel request)
        {
            Order order = new Order
            {
                ClientId = request.ClientId,
                ValueOrder = request.Value,
                ProductId = request.ProductId
            };

            _orderRepository.Insert(order);
        }

        public void Update(UpdateOrderModel request)
        {
            // Obter o pedido existente pelo ID
            var ord = _orderRepository.GetById(request.Id);

            // Verificar se o pedido existe
            if (ord != null)
            {
                // Atualizar apenas os campos que estão preenchidos no modelo de atualização
                if (request.ClientId != 0)
                {
                    ord.ClientId = request.ClientId;
                }

                // Verificar se Value foi atribuído (não é zero)
                if (request.Value != 0)
                {
                    ord.ValueOrder = request.Value;
                }

                // Verificar se ProductId foi atribuído (não é zero)
                if (request.ProductId != 0)
                {
                    ord.ProductId = request.ProductId;
                }

                // Chamar o método de atualização no repositório
                _orderRepository.Update(ord);
            }
            else
            {
                throw new Exception($"Pedido com ID {request.Id} não encontrado.");
            }
        }




        public void Delete(int id)
        {
            var user = _orderRepository.GetById(id);

            if (user == null)
                throw new Exception("pedido não encontrado");

            _orderRepository.Delete(id);
        }

        private OrderModel MapOrder(Order order)
        {

            var orderModel = new OrderModel
            {
                OrderId = order.Id,
                ClientId = order.ClientId,
                Cliente = order.ClientName,
                ProductId = order.ProductId,
                Produto = order.ProductName,
                ValorPedido = order.ValueOrder
            };

            return orderModel;
        }
        private List<OrderModel> MapOrdersList(List<Order> orders)
        {

            List<OrderModel> response = new List<OrderModel>();

            foreach (var item in orders)
            {
                var orderModel = new OrderModel
                {
                    OrderId = item.Id,
                    ClientId = item.ClientId,
                    Cliente = item.ClientName,
                    ProductId = item.ProductId,
                    Produto = item.ProductName,
                    ValorPedido = item.ValueOrder
                };

                response.Add(orderModel);
            }

            return response;
        }
    }
}
