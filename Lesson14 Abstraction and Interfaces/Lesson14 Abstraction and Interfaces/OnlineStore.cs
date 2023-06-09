public class OnlineStore : ITrade
{
    private string Name { get; set; }
    private decimal Money { get; set; }
    private int Tax { get; set; }

    private HashSet<Receipt> Story { get; set; } = new HashSet<Receipt>();
    public HashSet<Item> Items { get; set; } = new HashSet<Item>();
    public HashSet<Person> Persons { get; set; } = new HashSet<Person>();


    public OnlineStore(string Name, decimal Money, int Tax)
    {
        this.Name = Name;
        this.Money = Money;
        this.Tax = Tax;
    }

    public decimal GetMoney() => Money;
    public void Pay(decimal money) => Money -= money;
    public void AddMoney(decimal money) => Money += money;
 
    public string Purchase(string personName, string itemName, int quantity)
    {
        var item = Items.FirstOrDefault(x => x.ToString() == itemName);
        if (item == null)
            return "Item not found";
        if(item.GetQuantity() < quantity)
            return "Not enough product";

        var person = Persons.FirstOrDefault(x => x.ToString() == personName);
        if (person.Equals(default(Person))) // перевіряє значення за замовчуванням, якщо true то змінна пуста
            return "Person not found";

        var price = item.GetPrice() * (quantity + (quantity / 100 * Tax));
        if (person.GetMoney() > item.GetPrice() * quantity)
        {
            var newPerson = new Person(person.ToString(), person.GetMoney() - price);
            var newItem = new Item(item.ToString(), item.GetPrice(), item.GetQuantity() - quantity);

            Story.Add(new Receipt(person, item, price, quantity));

            Items.Remove(item); Items.Add(newItem);
            Persons.Remove(person); Persons.Add(newPerson);

            Money += price;
        }
        else
            return $"{personName} does not have enough money.";

        return $"{personName}, thank you for purchasing {itemName}";
    }
    public string PurchaseProductForStore(string itemName, int quantity)
    {
        var item = Items.FirstOrDefault(x => x.ToString() == itemName);
        if (item == null)
            return "Item not found";

        var price = item.GetPrice() * quantity;
        if (Money < price)
            return "Not enough money in the store";
        else
        {
            var newItem = new Item(item.ToString(), item.GetPrice(), item.GetQuantity() + quantity);
            Items.Remove(item); Items.Add(newItem);

            Money -= price;
            return $"Bought {quantity} units of {item.ToString()}";
        }
    }
    public string[] GetStory() => Story.Select(receipt => receipt.ToString()).ToArray();
    public override string ToString() => Name;
}
