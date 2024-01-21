namespace MultiFoods_Backend.Models
{
    public class OrderItemDTO
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public OrderDTO Order { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
