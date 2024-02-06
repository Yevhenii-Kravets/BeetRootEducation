namespace OnlineShop.Models
{
    public class OnlineShopModel
    {
        public string Name { get; set; } = "Shop model";
        public List<Item> Products = new List<Item>();
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Supplier { get; set; }
        public string CountryOrigin { get; set; }
        public decimal Price { get; set; }
    }
}
