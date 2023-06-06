namespace OOP_Module
{
    public class Group
    {
        private string Name { get; set; }
        private Cathedra? Cathedra { get; set; }
        private List<Student> Students { get; set; }
        private List<Lesson> Lessons { get; set; }

        // name
        public Group(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Group:Name is Empty");

            Students = new List<Student>();
            Lessons = new List<Lesson>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Group:Name is Empty");
        }

        // Cathedra
        public void PushCathedra(Cathedra Cathedra)
        {
            if (Cathedra == null)
                this.Cathedra = Cathedra;
            else
            {
                Cathedra.RemoveGroup(this.Name);
                this.Cathedra = Cathedra;
            }
        }

        // Students
        public bool AddStudent(Student Student)
        {
            bool isHave = false;
            foreach (var student in Students)
            {
                if (student.ToString() == Student.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Student.PushGroup(this);
                Students.Add(Student);
                return true;
            }

            return false;
        }
        public bool RemoveStudent(string nameStudent)
        {
            foreach (var student in Students)
            {
                if (student.ToString() == nameStudent)
                {
                    Students.Remove(student);
                    return true;
                }
            }
            return false;
        }
        public List<Student> GetStudents() => Students;

        // Lessons
        public void PushLesson(Lesson Lesson)
        {
            bool isHave = false;
            foreach (var lesson in Lessons)
            {
                if (lesson.ToString() == Lesson.ToString())
                    isHave = true;
            }

            if (!isHave)
                Lessons.Add(Lesson);
        }
        public bool AddLesson(Lesson Lesson)
        {
            bool isHave = false;
            foreach (var lesson in Lessons)
            {
                if (lesson.ToString() == Lesson.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Lesson.PushGroup(this);
                Lessons.Add(Lesson);
                return true;
            }

            return false;
        }
        public bool RemoveLesson(string nameLesson)
        {
            foreach (var lesson in Lessons)
            {
                if (lesson.ToString() == nameLesson)
                {
                    Lessons.Remove(lesson);
                    return true;
                }
            }
            return false;
        }
        public List<Lesson> GetLessons() => Lessons;

        // info
        public override string ToString() => Name;
    }
}
