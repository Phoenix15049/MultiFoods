namespace MultiFoods_Backend.Models
{
    public class RestaurantManagerDTO
    {
        public int Manager_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Restaurant_ID { get; set; }
        public RestaurantDTO Restaurant { get; set; }
    }
}
