namespace ControlePedidos.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string Cliente { get; set; }
        public int ProductId { get; set; }
        public string Produto { get; set; }
        public decimal ValorPedido { get; set; }

    }
}
