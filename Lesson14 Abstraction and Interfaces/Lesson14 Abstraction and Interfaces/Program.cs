internal class Program
{
    private static void Main(string[] args)
    {
        #region declared and filled

        Random random = new Random();

        OnlineStore store = new OnlineStore("MyStore", 10000m, 20);

        HashSet<Item> items = new HashSet<Item>();
        HashSet<Person> persons = new HashSet<Person>();

        string[] products = { "T-shirt", "Jeans", "Sneakers", "Backpack", "Watch", "Headphones", "Smartphone", "Book", "Handbag", "Tablet" };
        string[] names = { "John", "Emily", "Michael", "Sophia", "William", "Olivia", "James", "Ava", "Benjamin", "Emma" };

        int i = 10;
        while (i > 0)
        {

            Item item = new Item(
                products[random.Next(products.Length)] + random.Next(1000), // зменшив шанс дублю додавши цифру (HashSet) 
                random.Next(100, 301),
                random.Next(100));
            items.Add(item);

            Person person = new Person(
                names[random.Next(names.Length)] + random.Next(1000),
                random.Next(500, 2001));
            persons.Add(person);

            i--;
        }

        store.Items = items;
        store.Persons = persons;

        #endregion

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{store.ToString()}"
                            + $"\nMoney: {store.GetMoney()}");
            Console.WriteLine();
            Console.WriteLine("\n0. Exit"
                            + "\n1. Add shopper"
                            + "\n2. Add item"
                            + "\n3. Purchase a product"
                            + "\n4. Show history"
                            + "\n\n");

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0: // Exit
                    Environment.Exit(0);
                    break;

                case ConsoleKey.D1: // Add shopper
                    Console.WriteLine("\nEnter the name shopper: ");
                    var namePerson = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(namePerson))
                    {
                        Console.WriteLine("Name shopper is empty");
                        break;
                    }
                    Console.WriteLine("Enter the amount of money the buyer has: ");
                    var moneyIsTrue = int.TryParse(Console.ReadLine(), out var money);
                    if (moneyIsTrue)
                        store.Persons.Add(new Person(namePerson, money));
                    else
                        Console.WriteLine("Invalid value");

                    break;

                case ConsoleKey.D2: // Add item
                    Console.WriteLine("\nEnter the name item: ");
                    var nameItem = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nameItem))
                    {
                        Console.WriteLine("Name item is empty");
                        break;
                    }

                    Console.WriteLine("Enter the price item: ");
                    var priceIsTrue = decimal.TryParse(Console.ReadLine(), out var price);
                    if (priceIsTrue)
                        store.Items.Add(new Item(nameItem, price, 0));
                    else
                        Console.WriteLine("Invalid price item");

                    break;

                case ConsoleKey.D3: // Purchase a product
                    foreach (var item in store.Items)
                        Console.WriteLine(item.ToString());

                    Console.WriteLine("\nEnter the name item: ");
                    var searchItemName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(searchItemName))
                    {
                        Console.WriteLine("Name item is empty");
                        break;
                    }

                    Console.WriteLine("Enter the number of items: ");
                    var quantityIsTrue = int.TryParse(Console.ReadLine(), out var quantity);
                    if (quantityIsTrue)
                    {
                        var resultPurchase = store.PurchaseProductForStore(searchItemName, quantity);
                        Console.WriteLine(resultPurchase);
                    }
                    else
                        Console.WriteLine("Invalid quantity item");

                    break;

                case ConsoleKey.D4: // Show history
                    Console.WriteLine();
                    foreach (var receipt in store.GetStory())
                        Console.WriteLine("\n" + receipt);

                    Console.ReadLine();
                    continue;

                default: break;
            }
            
            // shopping simulation
            // використав for тому що foreach свариться на зміну колекцій
            for (int j = 0; j < store.Persons.Count; j++)
            {
                var purchase = store.Purchase(
                    store.Persons.OrderBy(x => Guid.NewGuid()).FirstOrDefault().ToString(),
                    store.Items.OrderBy(x => Guid.NewGuid()).FirstOrDefault().ToString(),
                    random.Next(1, 5));
                Console.WriteLine($"\n{purchase}\nMoney: {store.GetMoney()}$");
            }
            
            Console.ReadLine();
        }
    }
}
