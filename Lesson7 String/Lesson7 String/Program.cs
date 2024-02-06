using System.Text;

internal class Program
{
    enum CharIs
    {
        String,
        Digit,
        Symbol
    }

    static bool Compare(string string1, string string2)
    {
        int index = 0;
        // перевірка на null щоб не вилітала помилка
        if (string1.Length == string2.Length && string1 != null && string1 != null)
        {
            foreach (var i in string1)
                if (i != string2[index++]) return false;
        }
        else return false;

        return true;
    }

    // використав власний класс, вказаний знизу
    static Chars Analyze(string str)
    { 
        Chars chars = new ();
        foreach (var i in str)
        {
            chars.Letters += char.IsLetter(i) ? 1 : 0;
            chars.Digits += char.IsDigit(i) ? 1 : 0;
            chars.Symbols += char.IsSymbol(i) ? 1 : 0;
        }

        return chars;
    }
    static int Analyze(string str, CharIs charIs)
    {
        int amount = 0;
        foreach (var i in str)
            amount +=
                charIs == CharIs.Digit && char.IsDigit(i) ? 1 :
                charIs == CharIs.String && char.IsLetter(i) ? 1 :
                charIs == CharIs.Symbol && char.IsSymbol(i) ? 1 : 0;

        return amount;
    }

    static string Sort(string str)
    {
        // Bubble
        StringBuilder array = new (str);
        int length = array.Length - 1;

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < length; j++)
            {
                // до byte можна не приводити, але так ясніше 
                if ((byte)array[j] > (byte)array[j + 1])
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                }
            }
            length--;
        }
        return array.ToString();
    }

    static char[] Duplicate(string str)
    {
        StringBuilder stringBuilder = new ();

        for (int i = 0; i < str.Length - 1; i++)
        {
            for (int j = i + 1; j < str.Length; j++)
            {
                if (str[i] == str[j])
                {
                    bool has = false;

                    foreach (var e in stringBuilder.ToString().ToCharArray())
                        if (e == str[j])
                            has = true;

                    if (!has)
                        stringBuilder.Append(str[j]);
                }
            }
        }
        return stringBuilder.ToString().ToCharArray();
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Lesson 7 Strings\n");

        // Compare
        string compare_0 = "Evhenii";
        string compare_1 = "Evhenii ";
        string compare_2 = "evhenii";
        string compare_3 = "string";
        string compare_4 = "Evhenii";

        Console.WriteLine("Compare:"
            + $"\nString: '{compare_0}'"
            + $"\n == '{compare_1}': {Compare(compare_0, compare_1)}"
            + $"\n == '{compare_2}': {Compare(compare_0, compare_2)}"
            + $"\n == '{compare_3}': {Compare(compare_0, compare_3)}"
            + $"\n == '{compare_4}': {Compare(compare_0, compare_4)}");

        // Analyze
        string analyze = "qwerty123+-%";
        Chars chars = Analyze(analyze);

        Console.WriteLine("\nAnalyze:"
            + $"\nString: {analyze}"
            // variant 1
            + "\nVariant 1: "
            + $"letters: {chars.Letters}, digits: {chars.Digits}, symbols: {chars.Symbols}"
            // variant 2
            + "\nVariant 2: "
            + $"\nLetters: {Analyze(analyze, CharIs.String)}"
            + $"\nDigits: {Analyze(analyze, CharIs.Digit)}"
            + $"\nSymbols: {Analyze(analyze, CharIs.Symbol)}");

        // Sort
        string sort = "abcdefghi";
        string mixed = "ihgfedcba";

        Console.WriteLine("\nSort:"
            + $"\nString: {sort}"
            + $"\nMixed string: {mixed}"
            + $"\nSorted string: {Sort(mixed)}");

        // Duplicate
        string duplicate = "abbcccddddeff";
        char[] repeats = Duplicate(duplicate);

        Console.Write("\nDuplicate:"
            + $"\nString: {duplicate}\nRepeats: ");
        foreach (char c in repeats)
            Console.Write(c + " ");
    }
}

public class Chars
{
    public int Letters { get; set; }
    public int Digits { get; set; }
    public int Symbols { get; set; }
}