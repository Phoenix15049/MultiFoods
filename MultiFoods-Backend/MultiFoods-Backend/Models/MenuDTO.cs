namespace MultiFoods_Backend.Models
{
    public class MenuDTO
    {
        public int Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public int Restaurant_ID { get; set; }
        public RestaurantDTO Restaurant { get; set; }
    }
}
