
public class Wheel : Detail
{
    private Type TypeWheel { get; set; }

    public enum Type
    {
        AllSeason,
        AnyWeather,
        MudSnow,
        Winter
    }

    public Wheel(string Name, decimal Cost, bool isBroken, Type TypeWheel) : base(Name, Cost, isBroken)
    {
        this.TypeWheel = TypeWheel;
    }
}
