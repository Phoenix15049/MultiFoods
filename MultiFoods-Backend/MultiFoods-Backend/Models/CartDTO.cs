namespace MultiFoods_Backend.Models
{
    public class CartDTO
    {
        public int Cart_ID { get; set; }
        public int Customer_ID { get; set; }
        public int MenuItem_ID { get; set; }
        public int Quantity { get; set; }
        public CustomerDTO Customer { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
