namespace MultiFoods_Backend.Models
{
    public class OrderDTO
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
