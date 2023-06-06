namespace OOP_Module
{
    public class Cathedra
    {
        private string Name { get; set; }
        private Faculty? Faculty { get; set; }
        private List<Group> Groups { get; set; }
        private List<Teacher> Teachers { get; set; }

        // name
        public Cathedra(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Cathedra:Name is Empty");

            Groups = new List<Group>();
            Teachers = new List<Teacher>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Cathedra:Name is Empty");
        }

        // Faculty
        public void PushFaculty(Faculty Faculty)
        {
            if (Faculty == null)
                this.Faculty = Faculty;
            else
            {
                Faculty.RemoveCathedra(this.Name);
                this.Faculty = Faculty;
            }
        }

        // Groups
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
                Group.PushCathedra(this);
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

        //Teachers
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
                Teacher.PushCathedra(this);
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
                    teacher.RemoveCathedra(this.Name);
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
