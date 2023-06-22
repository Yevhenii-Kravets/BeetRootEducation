﻿using Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        IController controller = new MenuController();

        while (controller != null)
        {
            controller = controller.ExecuteAction();
        }

        Console.WriteLine("\nExecution has ended");
        Console.ReadLine();
    }
}