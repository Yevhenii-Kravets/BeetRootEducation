using System.Text.Json;

internal class Program
{
    const string FileName = "meetings.json";
    const int MaximumRoomLenght = 20;
    const int MaximumNameLenght = 50;
    const string Line = "+-----+" // ID 5
            + "--------------------+" // date 20
            + "---------------+" // dur 15
            + "--------------------+" // room 20
            + "--------------------------------------------------+"; // name 50

    static List<Meeting> Meetings = new List<Meeting>();
    static List<Meeting> SortedListBubble(List<Meeting> list)
    {
        int length = list.Count - 1;
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (list[j].StartTime > list[j + 1].StartTime)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
            length--;
        }
        return list;
    }

    static void WriteMeetings()
    {
        if (!File.Exists(FileName))
            File.Create(FileName).Close();

        string json = JsonSerializer.Serialize(Meetings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }
    static void ReadMeetings()
    {
        if (!File.Exists(FileName))
            File.Create(FileName);
        else
        {
            string json = File.ReadAllText(FileName);
            if (!string.IsNullOrEmpty(json))
                Meetings = JsonSerializer.Deserialize<List<Meeting>>(json);
        }
    }

    static int SetID()
    {
        int result = 0;
        if (Meetings.Count != 0)
        {
            foreach (var meeting in Meetings)
            {
                for (int j = 0; j < Meetings.Count; j++)
                {
                    if (result == Meetings[j].ID)
                    {
                        result++;
                        break;
                    }
                }
            }
        }
        return result;
    }
    static int ValidationID(string? id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            if (int.TryParse(id, out int result)) 
            {
                bool isFound = false;
                foreach (var meeting in Meetings)
                {
                    if (result == meeting.ID)
                        isFound = true;
                }

                if (isFound)
                    return result;
                else
                    throw new ArgumentException("ID not found");
            }
            else
                throw new ArgumentException("Non numeric value");
        }
        else
            throw new ArgumentException("Value is empty");

    }
    static DateTime ValidationDateTime(string? dateTime)
    {
        if (!string.IsNullOrWhiteSpace(dateTime))
        {
            if (DateTime.TryParse(dateTime, out DateTime result))
                return result;
            else
                throw new ArgumentException("Incorrect date or time format!");
        }
        else
            throw new ArgumentException("Empty value!");
    }
    static TimeSpan ValidationTimeSpan(string? timeSpan)
    {
        if (!string.IsNullOrWhiteSpace(timeSpan))
        {
            if (int.TryParse(timeSpan, out int minutes))
                return new TimeSpan(0, minutes, 0);
            else
                throw new ArgumentException("Incorrect format of duration!");
        }
        else
            throw new ArgumentException("Empty value!");
    }
    static string ValidationRoom(string? str, Meeting newMeeting, int lenght = 20)
    {
        if (!string.IsNullOrWhiteSpace(str))
        {
            if (str.Length > lenght)
                throw new ArgumentException($"The length of the room name is more than {lenght}");

            bool isBusy = false;
            foreach (var meeting in Meetings)
                if (str == meeting.Room &&
                    newMeeting.StartTime < meeting.StartTime + meeting.Duration &&
                    newMeeting.StartTime + newMeeting.Duration > meeting.StartTime)
                    isBusy = true;

            if (!isBusy)
                return str;
            else
                throw new ArgumentException("The room is busy");
        }
        else
            throw new ArgumentException("Empty value!");
    }
    static string ValidationString(string? str, int lenght = 50)
    {
        if (!string.IsNullOrWhiteSpace(str))
        {
            if (str.Length > lenght)
                throw new ArgumentException($"Value longer than limit {lenght}");
            return str;
        }
        else
            throw new ArgumentException("Empty value!");
    }

    static void ShowMeetings(int id = -1, string room = "")
    {
        Console.WriteLine(
            $"\n {Line}\n"
            + $" |{"ID",5}|"
            + $"{"START TIME",20}|"
            + $"{"DURATION",15}|"
            + $"{"ROOM",20}|"
            + $"{"NAME",50}|"
            + $"\n {Line}");

        bool isFound = false;
        foreach (var meeting in SortedListBubble(Meetings))
        {
            if (id == -1 && room == "")
            {
                Console.WriteLine($" |{meeting.ID,5}|"
                      + $"{meeting.StartTime,20}|"
                      + $"{meeting.Duration,15}|"
                      + $"{meeting.Room,20}|"
                      + $"{meeting.Name,50}|"
                      + $"\n {Line}");
                isFound = true;
            }
            else if (meeting.ID == id && room == "")
            {
                Console.WriteLine($" |{meeting.ID,5}|"
                      + $"{meeting.StartTime,20}|"
                      + $"{meeting.Duration,15}|"
                      + $"{meeting.Room,20}|"
                      + $"{meeting.Name,50}|"
                      + $"\n {Line}");
                isFound = true;
                //return;
            }
            else if (meeting.Room == room && id == -1)
            {
                Console.WriteLine($" |{meeting.ID,5}|"
                      + $"{meeting.StartTime,20}|"
                      + $"{meeting.Duration,15}|"
                      + $"{meeting.Room,20}|"
                      + $"{meeting.Name,50}|"
                      + $"\n {Line}");
                isFound = true;
            }
        }

        if (!isFound)
            Console.WriteLine("Meetings not found");

    }
    static void SearchMeetingsByRoom()
    {
        try
        {
            Console.WriteLine("\nEnter a room name: ");
            var room = ValidationString(Console.ReadLine(), MaximumRoomLenght);
            bool isFound = false;

            foreach (var meeting in Meetings)
                if (meeting.Room == room)
                {
                    isFound = true;
                    break;
                }

            if (isFound)
                ShowMeetings(-1, room);
            else
                throw new ArgumentException("Room not found");
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            Console.ReadLine();
            return;
        }
        Console.ReadLine();
    }

    static void AddMeeting()
    {
        Meeting meeting = new() { ID = SetID() };

        try
        {
            Console.Write("\nEnter the date and start time of the meeting: ");
            meeting.StartTime = ValidationDateTime(Console.ReadLine());

            Console.Write("\nEnter duration in minutes: ");
            meeting.Duration = ValidationTimeSpan(Console.ReadLine());

            Console.Write("\nEnter room: ");
            meeting.Room = ValidationRoom(Console.ReadLine(), meeting, MaximumRoomLenght);

            Console.Write("\nEnter name: ");
            meeting.Name = ValidationString(Console.ReadLine(), MaximumNameLenght);

        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            Console.ReadLine();
            return;
        }

        Meetings.Add(meeting);
        WriteMeetings();
    }
    static void DeleteMeeting()
    {
        try
        {
            Console.Write("\nEnter the meeting ID you want to delete: ");
            int id = ValidationID(Console.ReadLine());

            foreach (var meeting in Meetings)
                if (meeting.ID == id)
                {
                    Console.WriteLine($"\nMeeting {meeting.Name} scheduled for {meeting.StartTime} removed from {meeting.Room}");
                    Meetings.Remove(meeting);
                    WriteMeetings();
                    Console.ReadLine();
                    return;
                }
            Console.WriteLine("ID not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            return;
        }
    }
    static void EditMeeting()
    {
        try
        {
            Console.Write("\nEnter the meeting ID you want to edit: ");
            int id = ValidationID(Console.ReadLine());

            foreach (var meeting in Meetings)
            {
                if (meeting.ID == id)
                {
                    ShowMeetings(id);

                    Console.Write("\nEnter the date and start time of the meeting: ");
                    meeting.StartTime = ValidationDateTime(Console.ReadLine());

                    Console.Write("\nEnter the duration in minutes: ");
                    meeting.Duration = ValidationTimeSpan(Console.ReadLine());

                    Console.Write("\nEnter room: ");
                    meeting.Room = ValidationRoom(Console.ReadLine(), meeting, MaximumRoomLenght);

                    Console.Write("\nEnter name: ");
                    meeting.Name = ValidationString(Console.ReadLine(), MaximumNameLenght);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            return;
        }
        WriteMeetings();
    }

    static void Menu()
    {
        Console.Clear();

        if (Meetings.Count != 0)
            Console.WriteLine("5. Find meetings in a room"
                + "\n4. Show all meetings"
                + "\n3. Edit meeting"
                + "\n2. Delete meeting");
        Console.WriteLine("1. Add meeting"
            + "\n0. Exit calendar\n");
    }

    private static void Main(string[] args)
    {
        ReadMeetings();

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
                    SearchMeetingsByRoom();
                    break;
                case ConsoleKey.D4:
                    ShowMeetings();
                    Console.ReadLine();
                    break;
                case ConsoleKey.D3:
                    EditMeeting();
                    break;
                case ConsoleKey.D2:
                    DeleteMeeting();
                    break;
                case ConsoleKey.D1:
                    AddMeeting();
                    break;
                default: break;
            }
        }
    }
}

class Meeting
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Room { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime StartTime { get; set; }
}