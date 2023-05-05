using System.Diagnostics.Metrics;

internal class Program
{
    static int MaxInt(int a, int b)
    {
        return a > b ? a : b;
    }

    static int MaxInt(int a, int b, int c)
    {
        int ab = a > b ? a : b;
        return ab > c ? ab : c; 
    }

    static int MaxInt(int a, int b, int c, int d)
    {
        int ab = a > b ? a : b;
        int cd = c > d ? c : d;
        return ab > cd ? ab : cd;
    }

    static int MinInt(int a, int b)
    {
        return a < b ? a : b;
    }

    static int MinInt(int a, int b, int c)
    {
        int ab = a < b ? a : b;
        return ab < c ? ab : c;
    }

    static int MinInt(int a, int b, int c, int d)
    {
        int ab = a < b ? a : b;
        int cd = c < d ? c : d;
        return ab < cd ? ab : cd;
    }

    static bool TrySumIfOdd(int a, int b, out int result)
    {
        result = 0;
        int min = (a > b ? b : a);
        int max = (a < b ? b : a);

        for (int i = min; i <= max;)
            result += i++;
        return result % 2 != 0;
    }

    // EXTRA
    static string Repeat(string text, int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
            result += text;
        return result;
    }

    private static void Main(string[] args)
    {
        int result = 0;
        int A = 0, B = 0, C = 0, D = 0;

        Console.Write("Enter an integer A: ");
        bool AisTrue = int.TryParse(Console.ReadLine(), out A);
        Console.Write("Enter an integer B: ");
        bool BisTrue = int.TryParse(Console.ReadLine(), out B);
        Console.Write("Enter an integer C: ");
        bool CisTrue = int.TryParse(Console.ReadLine(), out C);
        Console.Write("Enter an integer D: ");
        bool DisTrue = int.TryParse(Console.ReadLine(), out D);

        if (AisTrue && BisTrue && CisTrue && DisTrue)
        {
            Console.WriteLine($"\nA > B: Max = {MaxInt(A, B)}, Min = {MinInt(A, B)}");
            Console.WriteLine($"\nA > B > C: Max = {MaxInt(A, B, C)}, Min = {MinInt(A, B, C)}");
            Console.WriteLine($"\nA > B > C > D: Max = {MaxInt(A, B, C, D)}, Min = {MinInt(A, B, C, D)}");
            Console.WriteLine($"\nThe sum of numbers A and B is odd: {TrySumIfOdd(A, B, out result)}, Sum: {result}");
        }
        else
            Console.WriteLine("Invalid value");

        // EXTRA
        Console.Write("\nEnter the number of repeats: ");
        int repeat = 0;
        bool repeatIsTrue = int.TryParse(Console.ReadLine(), out repeat);

        Console.Write($"Enter a string that is repeated {repeat} times: ");
        string text = Console.ReadLine();

        if (repeatIsTrue)
            Console.WriteLine("\n" + Repeat(text, repeat));
        else
            Console.WriteLine("Invalid value of repeats");
    }
}