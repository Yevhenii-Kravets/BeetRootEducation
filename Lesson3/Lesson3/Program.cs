using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Lesson3\n");

        int X = 0, Y = 0;
        Console.Write("Enter an integer X: ");
        bool XisTrue = int.TryParse(Console.ReadLine(), out X);
        Console.Write("Enter an integer Y: ");
        bool YisTrue = int.TryParse(Console.ReadLine(), out Y);

        if (XisTrue && YisTrue)
        {
            int result = 0;
            for (int i = (X > Y ? Y : X); i != (X < Y ? Y : X) + 1;)
                result += i++;
            Console.WriteLine("Sum: " + result);
        }
        else
            Console.WriteLine("Invalid input");
    }
}