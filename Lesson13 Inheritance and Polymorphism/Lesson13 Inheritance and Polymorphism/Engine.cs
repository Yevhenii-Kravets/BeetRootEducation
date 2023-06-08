
public class Engine : Detail
{
    public enum Type
    {
        Gasoline,
        Diesel,
        Gas
    }

    private Type TypeEngine { get; set; }

    public Engine(string Name, decimal Cost, bool isBroken, Type TypeEngine) : base(Name, Cost, isBroken)
    {
        this.TypeEngine = TypeEngine;
    }

}
