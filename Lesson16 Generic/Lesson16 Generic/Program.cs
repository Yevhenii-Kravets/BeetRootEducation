using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Lesson16_Generic.Stack<string> stack = new Lesson16_Generic.Stack<string>();

        stack.Push("");
        stack.Push("0");
        stack.Push("1");
        stack.Push("2");
        stack.Push("3");
        stack.Push("4");
        stack.Push("5");
        stack.Push("6");
        stack.Push("7");
        stack.Push("8");
        stack.Push("9");

        var count = stack.Count;
        Console.WriteLine($"Count: {count}");

        Console.WriteLine("\nGetEnumerator implementation for foreach");
        foreach(var item in stack)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nCopyTo(ref array)");
        var arrayV1 = new string[count];
        stack.CopyTo(ref arrayV1);
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Copied value {i}: {arrayV1[i]}");
        }

        Console.WriteLine("\nCopyTo()");
        var arrayV2 = stack.CopyTo();
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Copied value {i}: {arrayV2[i]}");
        }

        Console.WriteLine("\nStack Pop()");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"I: {i}, Value: {stack.Pop()}, Count: {stack.Count}");
        }
        // The stack is now empty
        // exception

        Console.WriteLine("\nStack Peek()");
        Console.WriteLine($"Upper value: {stack.Peek()}");

        Console.WriteLine("\nStack Clear()");
        Console.ReadLine();
        stack.Clear();

        Console.WriteLine(stack.Peek());

    }
}