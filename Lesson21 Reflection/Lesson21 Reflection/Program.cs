using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Enter the assembly path: ");
            var filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error file path");
                Console.ReadLine();
                continue;
            }

            foreach (Type clas in Assembly.LoadFrom(filePath).GetTypes())
            {
                Console.WriteLine("class " + clas.FullName); /*0*/
                Console.WriteLine("{");

                foreach (var method in clas.GetMethods())
                {
                    Console.Write($"\n   {method.ReturnType} {method.Name}("); /*3*/

                    bool isFirst = true;
                    foreach (var arg in method.GetParameters())
                        if (isFirst)
                        {
                            Console.Write($"{arg.ParameterType} {arg.Name}");
                            isFirst = false;
                        }
                        else
                            Console.Write($", {arg.ParameterType} {arg.Name}");

                    Console.WriteLine(");");
                }

                Console.WriteLine("}\n");
            }
            Console.ReadLine();
        }
    }
}