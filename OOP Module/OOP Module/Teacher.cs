namespace OOP_Module
{
    public class Teacher
    {
        private string Name { get; set; }
        private List<Lesson> Lessons { get; set; }
        private List<Cathedra> Cathedras { get; set; }

        // name
        public Teacher(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Teacher:Name is Empty");

            Lessons = new List<Lesson>();
            Cathedras = new List<Cathedra>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Teacher:Name is Empty");
        }

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
                Lesson.PushTeacher(this);
                Lessons.Add(Lesson);
                return true;
            }

            return false;
        }
        public bool RemoveLesson(string nameLesson)
        {
            foreach (var lesson in Lessons)
                if (lesson.ToString() == nameLesson)
                {
                    lesson.RemoveTeacher(this.Name);
                    Lessons.Remove(lesson);
                }


            return false;
        }
        public List<Lesson> GetLessons() => Lessons;

        // Cathedras
        public void PushCathedra(Cathedra Cathedra)
        {
            bool isHave = false;

            foreach(var cathedra in Cathedras)
            {
                if(cathedra.ToString() == Cathedra.ToString())
                    isHave = true;
            }

            if(!isHave)
                Cathedras.Add(Cathedra);
        }
        public bool AddCathedra(Cathedra Cathedra)
        {
            bool isHave = false;
            foreach (var cathedra in Cathedras)
            {
                if (cathedra.ToString() == Cathedra.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Cathedra.PushTeacher(this);
                Cathedras.Add(Cathedra);
                return true;
            }
            return false;
        }
        public bool RemoveCathedra(string nameCathedra)
        {
            foreach (var cathedra in Cathedras)
                if (cathedra.ToString() == nameCathedra)
                {
                    cathedra.RemoveTeacher(this.Name);
                    Cathedras.Remove(cathedra);                  
                }


                    return false;
        }
        public List<Cathedra> GetCathedras() => Cathedras;

        // info
        public override string ToString() => Name;
    }
}
