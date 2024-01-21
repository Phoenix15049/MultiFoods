namespace MultiFoods_Backend.Models
{
    public class CartDTO
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public CustomerDTO Customer { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
