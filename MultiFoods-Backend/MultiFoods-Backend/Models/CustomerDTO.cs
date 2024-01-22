namespace MultiFoods_Backend.Models
{
    public class CustomerDTO
    {
        public int? Customer_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
