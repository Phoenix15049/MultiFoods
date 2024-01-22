namespace MultiFoods_Backend.Models
{
    public class ItemsDto
    {
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public decimal Price { get; set; }
        public int Category_ID { get; set; }
    }

    // Restaurants.cs
    public class RestaurantsDto
    {
        public int Restaurant_ID { get; set; }
        public string Restaurant_Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    // Orders.cs
    public class OrdersDto
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public DateTime Order_Date { get; set; }
    }

    // OrderDetails.cs
    public class OrderDetailsDto
    {
        public int OrderDetail_ID { get; set; }
        public int Order_ID { get; set; }
        public int Item_ID { get; set; }
        public int Quantity { get; set; }
    }

    // Menus.cs
    public class MenusDto
    {
        public int Menu_ID { get; set; }
        public int Restaurant_ID { get; set; }
        public string Menu_Name { get; set; }
    }

    // MenuItems.cs
    public class MenuItemsDto
    {
        public int MenuItem_ID { get; set; }
        public int Menu_ID { get; set; }
        public int Item_ID { get; set; }
    }

    // Reviews.cs
    public class ReviewsDto
    {
        public int Review_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Restaurant_ID { get; set; }
        public string Review_Text { get; set; }
        public int Rating { get; set; }
    }
}
