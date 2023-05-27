using System.Text.Json;

internal class Program
{
    const string PhonebookPath = "phonebook.json";
    const int MaximumLength = 20;
    const string Line =
          "+--------------------+" // first 20
        + "--------------------+" // last 20
        + "--------------------+"; // num 20
    enum Attribute
    {
        Alphabet,
        LastName,
        Number
    }

    static List<Contact> Phonebook = new List<Contact>();
    static List<Contact> SortPhonebook(List<Contact> phonebook, Attribute sortType = Attribute.Alphabet)
    {
        switch (sortType)
        {
            case Attribute.Alphabet:
                return phonebook.OrderBy(contact => contact.FirstName)
                                     .ThenBy(contact => contact.LastName)
                                     .ThenBy(contact => contact.Number)
                                     .ToList();
            case Attribute.LastName:
                return phonebook.OrderBy(contact => contact.LastName).ToList();
            case Attribute.Number:
                return phonebook.OrderBy(contact => contact.Number).ToList();
            default: return phonebook;
        }
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

    static string ValidationNumber(string? str, string num = "")
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
                    {
                        if (contact.Number == num)
                            continue;
                        if (contact.Number == result)
                            isFound = true;
                    }
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
        Console.WriteLine($"\n {Line}\n"
            + $" |{"First name",20}|"
            + $"{"Last name",20}|"
            + $"{"Number",20}|"
            + $"\n {Line}");

        if (phonebook.Count >= 1)
            foreach (var contact in phonebook)
                Console.WriteLine($" |{contact.FirstName,20}|"
                      + $"{contact.LastName,20}|"
                      + $"{contact.Number,20}|"
                      + $"\n {Line}");
        else
            Console.WriteLine("No found contact");
    }
    static List<Contact> SearchContact()
    {
        List<Contact> phonebook = new List<Contact>();

        Attribute typeSearch = Attribute.Alphabet;
        bool pass = true;
        while (pass)
        {
            Console.Clear();
            Console.WriteLine("Select a search option: " +
                "\n3. First name" +
                "\n2. Last name" +
                "\n1. Number" +
                "\n0. Back\n");

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0 or ConsoleKey.Enter or ConsoleKey.Spacebar:
                    return null;
                case ConsoleKey.D1:
                    phonebook = SortPhonebook(Phonebook, Attribute.Number);
                    typeSearch = Attribute.Number;
                    pass = false;
                    break;
                case ConsoleKey.D2:
                    phonebook = SortPhonebook(Phonebook, Attribute.LastName);
                    typeSearch = Attribute.LastName;
                    pass = false;
                    break;
                case ConsoleKey.D3:
                    phonebook = SortPhonebook(Phonebook, Attribute.Alphabet);
                    typeSearch = Attribute.Alphabet;
                    pass = false;
                    break;
                default: break;
            }
        }

        Console.WriteLine("\nEnter the value: ");
        var searching = ValidationString(Console.ReadLine(), MaximumLength);

        int left = 0;
        int right = phonebook.Count - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int result = 0;
            if (typeSearch == Attribute.Alphabet)
                result = string.Compare(phonebook[mid].FirstName, searching);
            else if (typeSearch == Attribute.LastName)
                result = string.Compare(phonebook[mid].LastName, searching);
            else
                result = string.Compare(phonebook[mid].Number, searching);

            if (result < 0)
                left = mid + 1;
            else if (result > 0)
                right = mid - 1;
            else
                return new List<Contact>() { phonebook[mid] };
        }
        throw new Exception("No found contact");
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
    static void DeleteContact()
    {
        List<Contact> phonebook = new List<Contact>();
        try
        {
            phonebook = SearchContact();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (phonebook.Count == 0)
            Console.WriteLine("No contact found");
        else if (phonebook.Count > 1)
            Console.WriteLine("Specify contact details");
        else
        {
            while (true)
            {
                Console.Clear();
                ShowPhonebook(phonebook);

                Console.WriteLine("Delete this contact?\n0. No\n1. Yes");
                var keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        Phonebook.Remove(phonebook[0]);
                        WritePhonebook();
                        return;
                    default: break;
                }
            }

        }
    }
    static void EditContact()
    {
        List<Contact> phonebook = new List<Contact>();
        try
        {
            phonebook = SearchContact();


            if (phonebook.Count == 0)
                Console.WriteLine("No contact found");
            else if (phonebook.Count > 1)
                Console.WriteLine("Specify contact details");
            else
            {
                ShowPhonebook(phonebook);
                Console.Write("\nEnter first name: ");
                phonebook[0].FirstName = ValidationString(Console.ReadLine(), MaximumLength);

                Console.Write("\nEnter last name: ");
                phonebook[0].LastName = ValidationString(Console.ReadLine(), MaximumLength);

                Console.Write("\nEnter number: ");
                phonebook[0].Number = ValidationNumber(Console.ReadLine(), phonebook[0].Number);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        WritePhonebook();
        return;
    }

    static void Menu()
    {
        Console.Clear();

        if (Phonebook.Count != 0)
            Console.WriteLine("5. Delete contact"
                + "\n4. Edit contact"
                + "\n3. Search contact"
                + "\n2. Show all contacts");
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
            try
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D5:
                        DeleteContact();
                        break;
                    case ConsoleKey.D4:
                        EditContact();
                        break;
                    case ConsoleKey.D3:
                        ShowPhonebook(SearchContact());
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        ShowPhonebook(SortPhonebook(Phonebook));
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D1:
                        AddContact();
                        Console.ReadLine();
                        break;
                    default: break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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