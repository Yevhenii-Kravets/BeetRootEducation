internal class Program
{
    static int MultiplicationOrDivision(int a, int b, bool shouldDivine)
    {
        if (shouldDivine)
            return a / b;
        return a * b;
    }

    static bool CanDivideByTwo(int a)
    {
        return a % 2 == 0;
    }

    static int SumBetweenNumber(ref int X, int Y)
    {
        X = 10;
        int result = 0;
        for (int i = (X > Y ? Y : X); i != (X < Y ? Y : X) + 1;)
            result += i++;
        return result;
    }

    static bool TryParseInt(string value, out int parsedValue)
    {
        var parseResult = int.TryParse(value, out parsedValue);
        return parseResult;
    }

    static bool TryDivideByThree(int input, out int divisionResult)
    {
        divisionResult = input / 3;
        return input % 3 == 0;
    }

    //FIBONACCI
    static int SumFibonacci(int a)
    {
        int previousPreviousNumber = 0;
        int previousNumber = 1;
        int count = 3;
        int fiboSum = previousPreviousNumber + previousNumber;

        while(count <= a)
        {
            fiboSum += previousNumber + previousPreviousNumber;

            int temp = previousNumber;
            previousNumber = previousNumber + previousPreviousNumber;
            previousPreviousNumber = temp;

            count++;
        }

        return fiboSum;
    }
    /* HOMEWORK
    static int FibonacciSumRecursively(int a)
    {
        if (a == 1) return 0;
        if (a == 2) return 1;
        if (a == 3) return 2;
    }
    */
    static int GenerateRandomNumber(int min, int max)
    {
        return new Random().Next(min, max);
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    bool Add(int a, int b)
    {
        return (a + b) % 2 == 0;
    }

    private static void Main(string[] args)
    {
        int a = 24;
        int b = 2;
        int result = MultiplicationOrDivision(a, b, true);
        int result1 = SumBetweenNumber(ref a, b);
        string input = "100";
        int result2 = 0;
        int divisionByResult = 0;
        bool result3 = TryDivideByThree(a, out divisionByResult);

        if (TryParseInt(input, out result2))
            Console.WriteLine(divisionByResult);

        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        Console.WriteLine(GenerateRandomNumber(min, max));

    }
}