namespace MultiFoods_Backend.Models
{
    public class ReviewDTO
    {
        public int Review_ID { get; set; }
        public int Customer_ID { get; set; }
        public int MenuItem_ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public CustomerDTO Customer { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
