using System.Text.Json;

internal class Program
{
    const string PhonebookPath = "phonebook.json";
    const int MaximumLength = 20;
    const string Line =
          "+--------------------+" // first 20
        + "--------------------+" // last 20
        + "--------------------+"; // num 20

    static List<Contact> Phonebook = new List<Contact>();
    static List<Contact> SortPhonebook(List<Contact> phonebook)
    {
        phonebook = phonebook.OrderBy(contact => contact.FirstName)
                             .ThenBy(contact => contact.LastName)
                             .ThenBy(contact => contact.Number)
                             .ToList();
        return phonebook;
    }

    static void WritePhonebook()
    {
        if (!File.Exists(PhonebookPath))
            File.Create(PhonebookPath);

        string json = JsonSerializer.Serialize(Phonebook, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(PhonebookPath, json);
    }
    static void ReadPhonebook()
    {
        if (!File.Exists(PhonebookPath))
            File.Create(PhonebookPath);
        else
        {
            string json = File.ReadAllText(PhonebookPath);
            if (!string.IsNullOrEmpty(json))
                Phonebook = JsonSerializer.Deserialize<List<Contact>>(json);
        }
    }

    static string ValidationNumber(string? str)
    {
        string[] operators = { "039", "050", "063", "066", "067", "068", "091", "092", "093", "094",
                               "095", "096", "097", "098", "099", "031", "032", "033", "034", "035",
                               "036", "037", "038", "041", "042", "043", "044", "045", "046", "047",
                               "048", "049", "051", "052", "053", "054", "055", "056", "057", "058",
                               "059", "061", "062", "063", "064", "065", "069" };

        if (string.IsNullOrWhiteSpace(str))
            throw new ArgumentException("Empty value");
        else
        {
            string digits = new string(str.Where(char.IsDigit).ToArray());
            string number = "";

            if (string.IsNullOrEmpty(digits))
                throw new ArgumentException("Numbers not found");
            else
            {
                number = digits.Length switch
                {
                    12 when digits.StartsWith("380") => digits[2..],
                    10 when digits.StartsWith("0") => digits,
                    9 when operators.Any(op => digits.StartsWith(op[1..])) => "0" + digits,
                    _ => throw new ArgumentException("Wrong number format")
                };

                var result = "";

                if (number[0..4] == "0800" || number[0..4] == "0900")
                    result = "+38" + number;
                else
                    foreach (var oper in operators)
                        if (oper[1..] == number[1..3])
                        {
                            result = "+38" + number;
                            break;
                        }

                if (string.IsNullOrEmpty(result))
                    throw new Exception("No number exists");
                else
                {
                    bool isFound = false;
                    foreach (var contact in Phonebook)
                        if (contact.Number == result)
                            isFound = true;

                    if (isFound)
                        throw new ArgumentException("This number already exists");
                    else
                        return result;
                }
            }
        }
    }
    static string ValidationString(string? str, int lenght = 20)
    {
        if (string.IsNullOrWhiteSpace(str))
            throw new ArgumentException("Empty value!");

        if (str.Length > lenght)
            throw new ArgumentException($"Value longer than limit {lenght}");

        return str;
    }

    static void ShowPhonebook(List<Contact> phonebook)
    {
        Console.WriteLine(
            $"\n {Line}\n"
            + $" |{"First name",20}|"
            + $"{"Last name",20}|"
            + $"{"Number",20}|"
            + $"\n {Line}");

        foreach (var contact in SortPhonebook(phonebook))
        {
            Console.WriteLine($" |{contact.FirstName,20}|"
                  + $"{contact.LastName,20}|"
                  + $"{contact.Number,20}|"
                  + $"\n {Line}");
        }
    }
    static List<Contact> SearchContact()
    {
        var book = new List<Contact>();

        Console.Write("\nSearch: ");
        try
        {
            var str = ValidationString(Console.ReadLine(), MaximumLength);

            foreach (var contact in Phonebook)
                if ((contact.FirstName).ToLower().Contains(str.ToLower()) ||
                    (contact.LastName).ToLower().Contains(str.ToLower()) ||
                    (contact.Number).ToLower().Contains(str.ToLower()))
                    book.Add(contact);
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }

        return book;
    }

    static void AddContact()
    {
        Contact contact = new();

        try
        {
            Console.Write("\nEnter first name: ");
            contact.FirstName = ValidationString(Console.ReadLine(), MaximumLength);

            Console.Write("\nEnter last name: ");
            contact.LastName = ValidationString(Console.ReadLine(), MaximumLength);

            Console.Write("\nEnter number: ");
            contact.Number = ValidationNumber(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            return;
        }

        Phonebook.Add(contact);
        WritePhonebook();
    }
    static void DeleteContact(List<Contact> book)
    {
        if (book.Count == 0)
            Console.WriteLine("No contact found");
        else if (book.Count > 1)
            Console.WriteLine("Specify contact details");
        else
        {
            foreach (var contact in Phonebook)
            {
                if (contact == book[0])
                {
                    ShowPhonebook(book);

                    while (true) 
                    {
                        Console.WriteLine("Delete this contact?\n0. No\n1. Yes");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D0:
                                return; 
                            case ConsoleKey.D1:
                                Phonebook.Remove(contact);
                                WritePhonebook();
                                return;
                            default: break;
                        }
                    }
                }
            }
        }
    }
    static void EditContact(List<Contact> book)
    {
        if (book.Count == 0)
            Console.WriteLine("No contact found");
        else if (book.Count > 1)
            Console.WriteLine("Specify contact details");
        else
        {
            foreach (var contact in Phonebook)
            {
                if (contact == book[0])
                {
                    try
                    {
                        ShowPhonebook(book);
                        Console.Write("\nEnter first name: ");
                        contact.FirstName = ValidationString(Console.ReadLine(), MaximumLength);

                        Console.Write("\nEnter last name: ");
                        contact.LastName = ValidationString(Console.ReadLine(), MaximumLength);

                        Console.Write("\nEnter number: ");
                        contact.Number = ValidationNumber(Console.ReadLine());

                        WritePhonebook();
                        return;
                    }
                    catch (Exception e) 
                    { 
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }

    static void Menu()
    {
        Console.Clear();

        if (Phonebook.Count != 0)
            Console.WriteLine("5. Search contact"
                + "\n4. Show all contacts"
                + "\n3. Edit contact"
                + "\n2. Delete contact");
        Console.WriteLine("1. Add contact"
            + "\n0. Сlose phonebook\n");
    }

    private static void Main(string[] args)
    {
        ReadPhonebook();

        while (true)
        {
            Menu();
            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D5:
                    ShowPhonebook(SearchContact());
                    Console.ReadLine();
                    break;
                case ConsoleKey.D4:
                    ShowPhonebook(Phonebook);
                    Console.ReadLine();
                    break;
                case ConsoleKey.D3:
                    EditContact(SearchContact());
                    Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                    DeleteContact(SearchContact());
                    Console.ReadLine();
                    break;
                case ConsoleKey.D1:
                    AddContact();
                    break;
                default: break;
            }
        }
    }
}

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
}