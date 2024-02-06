public class Receipt
{
    private DateTime DateTime { get; set; }
    private Person Person { get; set; }
    private Item Item { get; set; } 
    private int Quantity { get; set; }
    private decimal Paid { get; set; }

    public Receipt(Person Person, Item Item, decimal Paid, int Quantity)
    {
        this.DateTime = DateTime.Now;
        this.Person = Person;
        this.Item = Item;
        this.Paid = Paid;
        this.Quantity = Quantity;
    }

    public override string ToString() => $"Time: {DateTime.ToString("HH:mm dd.MM.yyyy")}, " +
        $"\nСustomer name: {Person.ToString()}, " +
        $"\nItem: {Item.ToString()} x{Quantity} {Item.GetPrice()}$, " +
        $"\nPaid for: {Paid}$";
}
