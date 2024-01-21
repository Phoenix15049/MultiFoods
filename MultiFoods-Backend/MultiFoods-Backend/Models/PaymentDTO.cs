namespace MultiFoods_Backend.Models
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public OrderDTO Order { get; set; }
    }
}
