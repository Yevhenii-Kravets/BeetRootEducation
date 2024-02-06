namespace OOP_Module
{
    public class Lesson
    {
        private string Name { get; set; }
        private Room Room { get; set; }
        private List<Group> Groups { get; set; }
        private List<Teacher> Teachers { get; set; }

        // name
        public Lesson(string Name, Room room)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Lesson:Name is Empty");

            this.Room = room;

            Groups = new List<Group>();
            Teachers = new List<Teacher>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Lesson:Name is Empty");
        }

        // Room
        public void PushRoom(Room Room)
        {
            if (Room != null)
                this.Room = Room;
        }
        public string GetRoom() => Room.ToString();

        // Groups
        public void PushGroup(Group Group)
        {
            bool isHave = false;
            foreach (var group in Groups)
            {
                if (group.ToString() == Group.ToString())
                    isHave = true;
            }

            if (!isHave)
                Groups.Add(Group);
        }
        public bool AddGroup(Group Group)
        {
            bool isHave = false;
            foreach (var group in Groups)
            {
                if (group.ToString() == Group.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Group.PushLesson(this);
                Groups.Add(Group);
                return true;
            }

            return false;
        }
        public bool RemoveGroup(string nameGroup)
        {
            foreach (var group in Groups)
            {
                if (group.ToString() == nameGroup)
                {
                    Groups.Remove(group);
                    return true;
                }
            }
            return false;
        }
        public List<Group> GetGroups() => Groups;

        // Teachers
        public void PushTeacher(Teacher Teacher)
        {
            bool isHave = false;
            foreach (var teacher in Teachers)
            {
                if (teacher.ToString() == Teacher.ToString())
                    isHave = true;
            }

            if (!isHave)
                Teachers.Add(Teacher);
        }
        public bool AddTeacher(Teacher Teacher)
        {
            bool isHave = false;
            foreach (var teacher in Teachers)
            {
                if (teacher.ToString() == Teacher.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Teacher.PushLesson(this);
                Teachers.Add(Teacher);
                return true;
            }

            return false;
        }
        public bool RemoveTeacher(string nameTeacher)
        {
            foreach (var teacher in Teachers)
            {
                if (teacher.ToString() == nameTeacher)
                {
                    teacher.RemoveLesson(this.Name);
                    Teachers.Remove(teacher);
                    return true;
                }
            }
            return false;
        }
        public List<Teacher> GetTeachers() => Teachers;

        // info
        public override string ToString() => Name;
    }
}
