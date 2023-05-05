using System.Diagnostics.Metrics;

internal class Program
{
    #region HOMEWORK
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
    #endregion

    #region EXTRA
    static string Repeat(string text, int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
            result += text;
        return result;
    }
    #endregion

    #region ADDITIONAL
    // Count:     0  1  2  3  4  5  6   7   8   9  10  11   12   13   14   15   16    17    18    19    20     21     22
    // Fibonacci: 0  1  1  2  3  5  8  13  21  34  55  89  144  233  377  610  987  1597  2584  4181  6765  10946  17711
    // Sum:       0  1  2  4  7 12 20  33  54  88 143 232  376  609  986 1596 2583  4180  6764 10945 17710  28656  46367

    static int Fibonacci(int count) 
    {
        if (count <= 0) return 0;   
        else if (count == 1) return 1;
        else return Fibonacci(count - 1) + Fibonacci(count - 2);
    }

    static int SumFibonacci(int count)
    {
        if (count <= 0) return 0;
        else if (count == 1) return 1;
        else return Fibonacci(count) + SumFibonacci(count - 1);
    }
    #endregion

    private static void Main(string[] args)
    {
        // HOMEWORK
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

        Console.Write("\nEnter the number of repeats: ");
        int repeat = 0;
        bool repeatIsTrue = int.TryParse(Console.ReadLine(), out repeat);

        Console.Write($"Enter a string that is repeated {repeat} times: ");
        string text = Console.ReadLine();

        if (repeatIsTrue)
            Console.WriteLine("\n" + Repeat(text, repeat));
        else
            Console.WriteLine("Invalid value of repeats");

        // ADDITIONAL
        int count = 0;
        Console.Write("\nEnter the ordinal number of the Fibonacci number: ");
        bool CountIsTrue = int.TryParse(Console.ReadLine(), out count);

        if (CountIsTrue)
            Console.WriteLine("\nThe sum of the Fibonacci series: " + SumFibonacci(count));
        else
            Console.WriteLine("Invalid value of count");
    }
}