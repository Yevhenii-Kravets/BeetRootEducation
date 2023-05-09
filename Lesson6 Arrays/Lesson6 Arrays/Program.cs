internal class Program
{
    static int[] array = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static int[,] table = new int[10, 10];
    static int[,,] cube = new int[3, 3, 3];
    static int[][] jaggedArray = new int[3][];

    static void PrintAll(int[] array)
    {
        if (array.Length == 1000)
        {
            Console.WriteLine("Array is too big");
            return;
        }
    }

    static int[] Reverse(int[] array)
    {
        int[] newArray = new int[array.Length];
        int i = array.Length - 1;
        foreach (var element in array)
            newArray[i] = element;
        return newArray;
    }

    static void MultBy2(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            array[i] *= 2;
    }

    static int[] Copy(int[] array)
    {
        int[] newArray = new int[array.Length];
        int i = 0;

        foreach (int element in array)
            newArray[i++] = element * 2;
        return newArray;
    }

    static void InitArray(int[] array, int start, int end)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = start++;
            if (start > end)
                break;
        }
    }

    static int Sum(int[] array)
    {
        int sum = 0;

        foreach (int element in array)
            sum += element;
        return sum;
    }

    static int Sum(int[,] array)
    {
        int sum = 0;

        foreach (int element in array)
            sum += element;
        return sum;
    }

    static void InitTwoDimensionalArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = new Random().Next(100);
    }

    static void PrintTwoDimensionalArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }


    private static void Main(string[] args)
    {

        Console.WriteLine("Lesson 6 Arrays \n");


    }
}