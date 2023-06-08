public class Person
{
    private string Name { get; set; }
    protected decimal Money { get; set; }

    public Person(string Name, decimal Money)
    {
        this.Name = Name;
        this.Money = Money;
    }

    public decimal ShowMoney() => Money;
    public decimal Pay(decimal amount)
    {
        if (Money > amount)
        {
            Money -= amount;
            return amount;
        }
        return 0;
    }
}
