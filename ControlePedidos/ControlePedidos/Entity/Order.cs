namespace ControlePedidos.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ValueOrder { get; set; }
    }
}
