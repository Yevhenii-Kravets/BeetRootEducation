

public struct Person : ITrade
{
    private string Name { get; set; }
    private decimal Money { get; set; }

    public Person(string Name, decimal Money)
    {
        this.Name = Name;
        this.Money = Money;
    }

    public decimal GetMoney() => Money;
    public void Pay(decimal money) => Money -= money;
    public void AddMoney(decimal money) => Money += money;

    public override string ToString() => Name;
}
