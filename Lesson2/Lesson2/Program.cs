using static System.Math;

Console.WriteLine("Lesson2\n");

Console.WriteLine("Enter the X: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the Y: ");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Result: " +
    "\n-6 * x^3 + 5 * x^2 - 10 * x + 15 = " + (-6 * Pow(x, 3) + 5 * Pow(x, 2) - 10 * x + 15) +
    "\nabs(x) * sin(x) = " + (Abs(x) * Sin(x)) +
    "\n2 * pi * x = " + (2 * PI * x) +
    "\nmax(x, y) = " + (Max(x, y)));

