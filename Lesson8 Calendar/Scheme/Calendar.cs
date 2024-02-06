using System.Text.Json;

namespace Scheme
{
    public sealed class Calendar
    {
        private static Calendar? _instance;
        private const string FileNameMeetings = "Meetings.json";
        private const string FileNameRooms = "Rooms.json";

        private List<Meeting> Meetings { get; set; }
        private List<Room> Rooms { get; set; }

        private Calendar()
        {
            ReadFromJson();

            if (Meetings == null) Meetings = new List<Meeting>();
            if (Rooms == null) Rooms = new List<Room>();
        }

        public static Calendar GetInstance()
        {
            if (_instance == null)
                _instance = new Calendar();
            return _instance;
        }

        public List<Meeting> GetMeetings() => Meetings;
        public void AddMeeting(Guid guid, string Name, string roomName, TimeSpan duration, DateTime startTime)
        {
            Room room = null;
            foreach(var rom in Rooms)
                if(rom.Name == roomName)
                    room = rom;

            var meeting = new Meeting()
            {
                ID = guid,
                Name = Name,
                Room = room,
                Duration = duration,
                StartTime = startTime
            };

            Meetings.Add(meeting);
            SaveToJson();
        }
        public void RemoveMeeting(Meeting meeting)
        {
            Meetings.Remove(meeting);
            SaveToJson();
        }


        public List<Room> GetRooms() => Rooms;
        public void AddRoom(string name, int seats)
        {
            foreach (var room in Rooms)
                if (room.Name == name)
                    return;

            var newRoom = new Room()
            {
                Name = name,
                Seats = seats
            };
            Rooms.Add(newRoom);
            SaveToJson();
        }
        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
            SaveToJson();
        }

        private void SaveToJson()
        {
            if (!File.Exists(FileNameMeetings)) 
            {
                using (StreamWriter writer = new StreamWriter(FileNameMeetings)) { };
            }
            else
            {
                var jsonMeetings = JsonSerializer.Serialize(Meetings);
                File.WriteAllText(FileNameMeetings, jsonMeetings);
            }

            if (!File.Exists(FileNameRooms))
            {
                using (StreamWriter writer = new StreamWriter(FileNameRooms)) { };
            }
            else
            {
                var jsonRooms = JsonSerializer.Serialize(Rooms);
                File.WriteAllText(FileNameRooms, jsonRooms);
            }
        }
        private void ReadFromJson()
        {
            if (!File.Exists(FileNameMeetings)) 
            {
                File.Create(FileNameMeetings).Close();
            }
            else
            {
                var json = File.ReadAllText(FileNameMeetings);

                if (!string.IsNullOrWhiteSpace(json))
                    Meetings = JsonSerializer.Deserialize<List<Meeting>>(json);
            }

            if (!File.Exists(FileNameRooms))
            {
                File.Create(FileNameRooms).Close();
            }
            else
            {
                var json = File.ReadAllText(FileNameRooms);

                if (!string.IsNullOrWhiteSpace(json))
                    Rooms = JsonSerializer.Deserialize<List<Room>>(json);
            }
        }
    }

}