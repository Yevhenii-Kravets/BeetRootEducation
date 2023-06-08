
public class Autoservice
{
    private string Name { get; set; }
    private decimal Money { get; set; }

    private List<Automechanic> Automechanics { get; set; } = new List<Automechanic>();
    private List<Car> Cars { get; set; } = new List<Car>();
    private List<Detail> Details { get; set; } = new List<Detail>();

    public Autoservice(string Name, decimal Money, List<Automechanic> Automechanics, List<Car> Cars, List<Detail> Details)
    {
        this.Name = Name;
        this.Money = Money;
        this.Automechanics = Automechanics;
        this.Cars = Cars;
        this.Details = Details;
    }

    public override string ToString() => Name;
    public string ShowMoney() => Money.ToString();
    public int GetCountCars() => Cars.Count;

    public void AddCar(Car car)
    {
        if (Cars.Count < Automechanics.Count)
            Cars.Add(car);
        else
            Console.WriteLine("No available automechanics");
    }
    public void RemoveCars()
    {
        foreach (var car in Cars)
            if (car.GetBrokenDetail() == null)
                Cars.Remove(car);
    }
    public bool Salary()
    {
        foreach (var automechanic in Automechanics)
        {
            automechanic.AddMoney(500);
            if ((Money -= 500) < 0)
                return false;
        }
        return true;
    }
    public void FixCars()
    {
        List<Car> removeCars = new List<Car>();
        foreach (var car in Cars)
        {
            Detail? detail = car.GetBrokenDetail();
            if (detail is Engine engine)
            {
                if (car.GetDriver().ShowMoney() < car.GetCostEngine())
                    removeCars.Add(car);
                else
                {
                    Money += car.GetDriver().Pay(car.GetCostEngine());
                    car.SetNewEngine(engine);
                }
            }
            if (detail is Transmission transmission)
            {
                if (car.GetDriver().ShowMoney() < car.GetCostEngine())
                    removeCars.Add(car);
                else
                {
                    Money += car.GetDriver().Pay(car.GetCostTransmission());
                    car.SetNewTransmission(transmission);
                }
            }
            if (detail is Wheel wheel)
            {
                if (car.GetDriver().ShowMoney() < car.GetCostEngine())
                    removeCars.Add(car);
                else
                {
                    Money += car.GetDriver().Pay(car.GetCostWheel());
                    car.SetNewWheel(wheel);
                }
            }
        }

        if (removeCars.Count > 0)
            foreach (var car in removeCars)
                Cars.Remove(car);

    }
}
