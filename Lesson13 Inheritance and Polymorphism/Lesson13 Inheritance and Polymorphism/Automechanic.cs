public class Automechanic : Person
{
    public Automechanic(string Name, decimal Money) : base(Name, Money) { }
    public void AddMoney(decimal amount) { Money += amount; }
}
