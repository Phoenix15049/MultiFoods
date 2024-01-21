namespace MultiFoods_Backend.Models
{
    public class PaymentDTO
    {
        public int Payment_ID { get; set; }
        public int Order_ID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public OrderDTO Order { get; set; }
    }
}
