namespace MultiFoods_Backend.Models
{
    public class OrderCreateModel
    {
        public int Customer_ID { get; set; }


    }


    public class CreateOrderDTO
    {
        public int Customer_ID { get; set; }
        public List<MenuItemDTO> MenuItems { get; set; }
    }

}
