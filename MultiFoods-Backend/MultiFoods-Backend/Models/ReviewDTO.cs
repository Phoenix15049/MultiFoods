namespace MultiFoods_Backend.Models
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public int CustomerID { get; set; }
        public int MenuItemID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public CustomerDTO Customer { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
