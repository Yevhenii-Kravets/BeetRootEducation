using Lesson20_LINQ;
using Newtonsoft.Json;

internal class Program
{
    private const string FileName = "data.json";

    private static IEnumerable<MyPerson>? Peoples;

    static void ReadFile()
    {
        if (!File.Exists(FileName))
            File.Create(FileName);
        else
        {
            string json = File.ReadAllText(FileName);
            if (!string.IsNullOrEmpty(json))
                Peoples = JsonConvert.DeserializeObject<IEnumerable<MyPerson>>(json);
        }
    }
    static int Intersections(string text1, string text2)
    {
        var words1 = text1.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var words2 = text2.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        return words1.Intersect(words2).Count();
    }

    private static void Main(string[] args)
    {
        ReadFile();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Console.WriteLine(
            "\n\nfind out who is located farthest north / south / west / east using latitude/ longitude data");
        //             Latitude
        //                |
        //                N
        //              W + E - Longitude
        //                S

        var north = Peoples.OrderByDescending(p => p.Latitude).First();
        Console.WriteLine("north: " + north.Longitude);

        var south = Peoples.OrderBy(p => p.Latitude).First();
        Console.WriteLine("south: " + south.Latitude);

        var west = Peoples.OrderBy(p => p.Longitude).First();
        Console.WriteLine("west: " + west.Longitude);

        var east = Peoples.OrderByDescending(p => p.Longitude).First();
        Console.WriteLine("east: " + east.Longitude);

        ////////////////////////////////////////////////////////////////
        Console.WriteLine("\n\nfind max and min distance between 2 persons");

        var maxDistance = Peoples
            .SelectMany(person1 => Peoples, (person1, person2) => new { Person1 = person1, Person2 = person2 })
            .Where(pair => pair.Person1 != pair.Person2)
            .OrderByDescending(pair => PointExtensions.Distance(
                                       new Point(pair.Person1.Latitude, pair.Person1.Longitude),
                                       new Point(pair.Person2.Latitude, pair.Person2.Longitude)))
            .FirstOrDefault();
        Console.WriteLine($"The maximum distance between {maxDistance.Person1.Name} and {maxDistance.Person2.Name} it is: "
            + PointExtensions.Distance(new Point(maxDistance.Person1.Latitude, maxDistance.Person1.Longitude),
                                       new Point(maxDistance.Person2.Latitude, maxDistance.Person2.Longitude)));

        var minDistance = Peoples
            .SelectMany(person1 => Peoples, (person1, person2) => new { Person1 = person1, Person2 = person2 })
            .Where(pair => pair.Person1 != pair.Person2)
            .OrderBy(pair => PointExtensions.Distance(
                                       new Point(pair.Person1.Latitude, pair.Person1.Longitude),
                                       new Point(pair.Person2.Latitude, pair.Person2.Longitude)))
            .FirstOrDefault();
        Console.WriteLine($"The minimum distance between {minDistance.Person1.Name} and {minDistance.Person2.Name} it is: "
            + PointExtensions.Distance(new Point(minDistance.Person1.Latitude, minDistance.Person1.Longitude),
                                       new Point(minDistance.Person2.Latitude, minDistance.Person2.Longitude)));

        /////////////////////////////////////////////////////////////////////////
        Console.WriteLine("\n\nfind 2 persons whos ‘about’ have the most same words");

        var intersectionPersons = Peoples
            .SelectMany(person1 => Peoples.Where(person => person.Id != person1.Id), (person1, person2) =>
                                                          new { Person1 = person1, Person2 = person2 })
            .OrderByDescending(pair => Intersections(pair.Person1.About, pair.Person2.About))
            .FirstOrDefault();
        Console.WriteLine($"{intersectionPersons.Person1.Name} and {intersectionPersons.Person2.Name} are the most similar");

        /////////////////////////////////////////////////////////////////////////////
        Console.WriteLine("\n\nfind persons with same friends(compare by friend’s name)");

        var commonFriends = Peoples
            .SelectMany(person1 => Peoples.Where(person => person.Id != person1.Id), (person1, person2) => 
                                                          new { Person1 = person1, Person2 = person2 })
            .Where(pair => pair.Person1.Friends.
                   Any(friend1 => pair.Person2.Friends.
                   Any(friend2 => friend1.Name == friend2.Name)))
            .ToList();

        Console.WriteLine("couples with common friends: ");
        foreach (var pair in commonFriends)
        {
            Console.WriteLine($"Common friends {pair.Person1.Name} and {pair.Person1.Name}:");

            var friends = pair.Person1.Friends
                .Join(pair.Person2.Friends, friend1 => friend1.Name, friend2 => friend2.Name, (friend1, friend2) => friend1);
            
            foreach (var friend in friends)
            {
                Console.WriteLine($" |{friend.Name}");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}