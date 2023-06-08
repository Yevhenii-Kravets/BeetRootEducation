
public class Transmission : Detail
{
    public enum Type
    {
        Manual,
        Automatic,
        Robotic
    }

    private Type TypeTransmission { get; set; }

    public Transmission(string Name, decimal Cost, bool isBroken, Type TypeTransmission) : base(Name, Cost, isBroken)
    {
        this.TypeTransmission = TypeTransmission;
    }
}
