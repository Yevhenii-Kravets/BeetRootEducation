using static System.Math;
using static System.DateTime;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Lesson2\n");

        Console.WriteLine("Enter the X: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the Y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nResult: " +
            "\n-6 * x^3 + 5 * x^2 - 10 * x + 15 = " + (-6 * Pow(x, 3) + 5 * Pow(x, 2) - 10 * x + 15) +
            "\nabs(x) * sin(x) = " + Abs(x) * Sin(x) +
            "\n2 * pi * x = " + 2 * PI * x +
            "\nmax(x, y) = " + Max(x, y));

        Console.WriteLine("\n{0} days left to New Year" +
            "\n{1} days passed from New Year", 
            (new DateTime(Now.Year + 1, 1, 1) - Now).Days, 
            (Now - new DateTime(Now.Year, 1, 1)).Days);

        byte _byte = 255;
        short _short = 32767;
        int _int = 2147483647;
        long _long = 9223372036854775807;
        bool _bool = true;
        char _char = 't';
        float _float = -11.123456789f;
        double _double = -11.123456789;
        decimal _decimal = -11.123456789m;
        string _string = "tex";

        Console.WriteLine("\nResult: " +
            "\n(short)32767 * (float)-11.123456789f = (float)" + (_short * _float) +
            "\n(int)2147483647 / (double)-11.123456789 = (double)" + (_int / _double) +
            "\n(long)9223372036854775807 - (decimal)-11.123456789m = (decimal)" + (_long - _decimal) +
            "\n(string)tex + (char)t = (string)" + (_string + _char) + 
            "\n((byte)255 > 254) == (bool)true = (bool)" + ((_byte > 254) == _bool));

    }
}