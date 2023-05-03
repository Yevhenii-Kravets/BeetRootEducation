using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Lesson3\n");

        Console.Write("Enter an integer X: ");
        int X = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer Y: ");
        int Y = int.Parse(Console.ReadLine());


        int result = 0;
        for (int i = (X > Y ? Y : X); i != (X < Y ? Y : X) + 1;)
            result += i++;
        Console.WriteLine(result);
    }
}