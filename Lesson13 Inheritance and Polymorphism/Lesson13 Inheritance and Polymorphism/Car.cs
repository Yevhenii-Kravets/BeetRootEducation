
public class Car
{
    private string Name { get; set; }
    private string Model { get; set; }

    private Person Driver { get; set; }
    private Engine Engine { get; set; }
    private Wheel[] Wheels { get; set; } = new Wheel[3];
    private Transmission Transmission { get; set; }

    public Car(string Name, string Model, Person Driver, Engine Engine, Wheel[] Wheels, Transmission Transmission)
    {
        this.Name = Name;
        this.Model = Model;
        this.Driver = Driver;
        this.Engine = Engine;
        this.Wheels = Wheels;
        this.Transmission = Transmission;
    }

    public Detail? GetBrokenDetail()
    {
        List<Detail> details = new List<Detail>();
        if (Engine.IsBroken())
            return Engine;

        if (Transmission.IsBroken())
            return Transmission;

        foreach (var Wheel in Wheels)
            if (Wheel.IsBroken())
                return Wheel;

        return null;
    }

    public void SetNewEngine(Engine Engine)
    {
        if (Engine.IsBroken())
            this.Engine = Engine;
    }
    public void SetNewTransmission(Transmission Transmission)
    {
        if (Transmission.IsBroken())
            this.Transmission = Transmission;
    }
    public void SetNewWheel(Wheel Wheel)
    {
        for (int i = 0; i < Wheels.Length; i++)
            if (Wheels[i].IsBroken())
                Wheels[i] = Wheel;

    }
    public decimal GetCostEngine() => Engine.GetCost();
    public decimal GetCostTransmission() => Transmission.GetCost();
    public decimal GetCostWheel()
    {
        foreach (var wheel in Wheels)
        {
            if(wheel.IsBroken())
                return wheel.GetCost();
        }
        return 0;
    }

    public Person GetDriver() => Driver;
}
