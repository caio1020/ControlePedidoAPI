namespace ControlePedidos.Model
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Value { get; set; }
        public int ProductId { get; set; }
    }
}
