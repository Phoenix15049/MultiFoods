namespace MultiFoods_Backend.Models
{
    public class OrderItemDTO
    {
        public int OrderItem_ID { get; set; }
        public int Order_ID { get; set; }
        public int MenuItem_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public OrderDTO Order { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
