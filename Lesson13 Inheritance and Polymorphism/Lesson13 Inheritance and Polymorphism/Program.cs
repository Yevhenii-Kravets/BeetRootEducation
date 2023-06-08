using System;

internal partial class Program
{
    static Random Random = new Random();

    static string[] CarNames = new string[] { "Toyota", "Honda", "Ford", "Chevrolet", "BMW", "Mercedes", "Audi", "Tesla", "Volkswagen", "Jeep" };
    static string[] CarModels = new string[] { "M3", "S", "I4", "Corvette", "X5", "C-Class", "Q7", "Model 3", "GTI", "Wrangler" };
    static string[] DriverNames = new string[] { "John", "Emily", "Michael", "Sophia", "William", "Olivia", "James", "Ava", "Benjamin", "Emma" };
    static string[] EngineModels = new string[] { "V6", "Inline-4", "V8", "Turbocharged", "Hybrid", "Electric", "Rotary", "Boxer", "Diesel", "Supercharged" };
    static string[] WheelNames = new string[] { "Winter", "All-Season", "Performance", "Off-Road", "Touring", "Run-Flat", "Summer", "Mud-Terrain", "High-Performance", "Low-Profile" };
    static string[] TransmissionModels = new string[] { "Automatic", "Manual", "CVT", "Semi-Automatic", "Dual-Clutch", "Tiptronic", "SportShift", "Steptronic", "eCVT", "AMT" };

    static Dictionary<int, string> WeekDays = new Dictionary<int, string>()
    {
        { 1, "Monday" },
        { 2, "Tuesday" },
        { 3, "Wednesday" },
        { 4, "Thursday" },
        { 5, "Friday" },
        { 6, "Saturday" },
        { 7, "Sunday" }
    };

    public static void ShowInfo(ref Autoservice autoservice, int day, int weekDay)
    {
        Console.WriteLine($"Days in Game {day}, weekday { WeekDays[weekDay] }");
        Console.WriteLine($"Authoservice: {autoservice.ToString()}");
        Console.WriteLine($"Money: {autoservice.ShowMoney()}$");
        Console.WriteLine($"Cars in repair: {autoservice.GetCountCars()}");
    }
    public static void NewCar(ref Autoservice autoservice)
    {


        Console.WriteLine("The car came, service it?");
        Console.WriteLine("0. No \n1. Yes");

        var keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                string carName = CarNames[Random.Next(CarNames.Length)];
                string carModel = CarModels[Random.Next(CarModels.Length)];
                string driverName = DriverNames[Random.Next(DriverNames.Length)];
                string engineModel = EngineModels[Random.Next(EngineModels.Length)];
                string wheelName = WheelNames[Random.Next(WheelNames.Length)];
                var wheelType = (Wheel.Type)Random.Next(Enum.GetValues(typeof(Wheel.Type)).Length);
                string transmissionModel = TransmissionModels[Random.Next(TransmissionModels.Length)];


                Car car = new Car(carName, carModel,
                    new Person(driverName, Random.Next(200, 1001)),
                    new Engine(engineModel, Random.Next(200, 500), Random.Next(2) == 0, (Engine.Type)Random.Next(Enum.GetValues(typeof(Engine.Type)).Length)),
                    new Wheel[]
                    {
                        new Wheel(wheelName, Random.Next(50, 101), Random.Next(2) == 0, wheelType),
                        new Wheel(wheelName, Random.Next(50, 101), Random.Next(2) == 0, wheelType),
                        new Wheel(wheelName, Random.Next(50, 101), Random.Next(2) == 0, wheelType),
                        new Wheel(wheelName, Random.Next(50, 101), Random.Next(2) == 0, wheelType)
                    },
                    new Transmission(transmissionModel, Random.Next(100, 301), Random.Next(2) == 0, (Transmission.Type)Random.Next(Enum.GetValues(typeof(Transmission.Type)).Length))
                    );
                autoservice.AddCar(car);
                break;
            case ConsoleKey.D0:
                return;
            default: break;
        }
    }

    private static void Main(string[] args)
    {
        Automechanic valera = new Automechanic("Valera", 100);
        Automechanic vityok = new Automechanic("Vityok", 10);

        Autoservice autoservice = new Autoservice("Renovating with love", 1000,
            new List<Automechanic> { valera, vityok },
            new List<Car>(),
            new List<Detail>());

        int day = 1;
        int weekDay = 1;
        while (true)
        {
            Console.Clear();
            autoservice.RemoveCars();

            ShowInfo(ref autoservice, day, weekDay);
            Console.ReadLine();

            NewCar(ref autoservice);
            Console.WriteLine();

            autoservice.FixCars();

            if (weekDay % 7 == 0)
            {
                if (!autoservice.Salary())
                {
                    Console.WriteLine("You're bankrupt!");
                    Console.ReadLine();
                    break;
                }
                else
                    Console.WriteLine("Salary paid!");

                weekDay = 1;
            }
            else
                weekDay += 1;

            day += 1;
            Console.ReadLine();
        }
    }
}