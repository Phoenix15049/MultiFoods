namespace MultiFoods_Backend.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
