internal class Program
{
    enum SortAlgorithmType
    {
        Selection,
        Bubble,
        Insertion
    }
    enum OrderBy
    {
        Asc,
        Desc
    }

    static int[] CreateAndFillRandomArray(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
            array[i] = new Random().Next(99);
        return array;
    }
    static void PrintArray(int[] array)
    {
        int index = 0;
        foreach (var i in array)
            Console.WriteLine($"{index++} {i}");
    }
    static int[] ReverseArray(int[] array)
    {
        int index = array.Length - 1;
        for (int i = 0; i < array.Length / 2; i++)
        {
            int temp = array[i];
            array[i] = array[index - i];
            array[index - i] = temp;
        }
        return array;
    }

    static int[] SortedArraySelection(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[min] > array[j])
                    min = j;

            int temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        return array;
    }
    static int[] SortedArraySelection(int[] array, OrderBy orderBy)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[min] > array[j] && orderBy == OrderBy.Asc)
                    min = j;
                else if (array[min] < array[j] && orderBy == OrderBy.Desc)
                    min = j;
            }

            int temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        return array;
    }

    static int[] SortedArrayBubble(int[] array)
    {
        // з кожною ітерацією кількість ітерацій вкладеного for зменшується на одну
        // так як нема сенсу перевіряти останній елемент
        // таким чином кількість ітерацій зменшується з 9801 до 4950 за умови що массив із 100 елементів
        int length = array.Length - 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
            length--;
        }
        return array;
    }
    static int[] SortedArrayBubble(int[] array, OrderBy orderBy)
    {
        // з кожною ітерацією кількість ітерацій вкладеного for зменшується на одну
        // так як нема сенсу перевіряти останній елемент
        // таким чином кількість ітерацій зменшується з 9801 до 4950 за умови що массив із 100 елементів
        int length = array.Length - 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (array[j] > array[j + 1] && orderBy == OrderBy.Asc)
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
                else if (array[j] < array[j + 1] && orderBy == OrderBy.Desc)
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
            length--;
        }
        return array;
    }

    static int[] SortedArrayInsertion(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int temp = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > temp)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = temp;
        }
        return array;
    }
    static int[] SortedArrayInsertion(int[] array, OrderBy orderBy)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int temp = array[i];
            int j = i - 1;

            if (orderBy == OrderBy.Asc)
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }

            if (orderBy == OrderBy.Desc)
                while (j >= 0 && array[j] < temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
            array[j + 1] = temp;
        }
        return array;
    }

    static int[] Sort(int[] array, SortAlgorithmType sortType)
    {
        switch (sortType)
        {
            case SortAlgorithmType.Selection:
                return SortedArraySelection(array);
            case SortAlgorithmType.Bubble:
                return SortedArrayBubble(array);
            case SortAlgorithmType.Insertion:
                return SortedArrayInsertion(array);
            default:
                throw new ArgumentException("error");
        }
    }
    static int[] Sort(int[] array, SortAlgorithmType sortType, OrderBy orderBy = OrderBy.Asc)
    {
        switch (sortType)
        {
            case SortAlgorithmType.Selection:
                SortedArraySelection(array);
                break;
            case SortAlgorithmType.Bubble:
                SortedArrayBubble(array);
                break;
            case SortAlgorithmType.Insertion:
                SortedArrayInsertion(array);
                break;
        }

        if (orderBy == OrderBy.Asc)
            return array;
        else 
            return ReverseArray(array);
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Lesson 6 Arrays\n");

        var array = CreateAndFillRandomArray(100);
        PrintArray(array);

        Console.WriteLine();

        Sort(array, SortAlgorithmType.Insertion, OrderBy.Desc);
        PrintArray(array);

        //PrintArray(Sort(CreateAndFillRandomArray(100), SortAlgorithmType.Bubble, OrderBy.Desc));
    }
}
