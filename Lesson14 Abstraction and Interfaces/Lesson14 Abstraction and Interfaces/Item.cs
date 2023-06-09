public class Item
{
    private string Name { get; set; }
    private decimal Price { get; set; }
    private int Quantity { get; set; }

    public Item(string Name, decimal Price, int Quantity)
    {
        this.Name = Name;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public int GetQuantity() => Quantity;
    public decimal GetPrice() => Price;
    public void Sell(int quantity) => Quantity -= quantity;
    public void Buy(int quantity) => Quantity += quantity;

    public override string ToString() => Name;
}
