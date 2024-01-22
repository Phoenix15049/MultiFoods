namespace MultiFoods_Backend.Models
{
    public class MenuItemDTO
    {
        public int MenuItem_ID { get; set; }
        public string Item_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Category_ID { get; set; }
        public int Menu_ID { get; set; }
        //public CategoryDTO Category { get; set; }
        //public MenuDTO Menu { get; set; }
    }
}
