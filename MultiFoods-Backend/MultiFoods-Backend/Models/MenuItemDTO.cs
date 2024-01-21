namespace MultiFoods_Backend.Models
{
    public class MenuItemDTO
    {
        public int MenuItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
