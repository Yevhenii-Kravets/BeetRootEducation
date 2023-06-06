using OOP_Module;

internal class Program
{
    private static void Main(string[] args)
    {
        University university = new University("University1");

        Faculty faculty1 = new Faculty("Faculty1");
        Faculty faculty2 = new Faculty("Faculty2");

        Cathedra cathedra1 = new Cathedra("Cathedra1");
        Cathedra cathedra2 = new Cathedra("Cathedra2");

        Group group1 = new Group("Group1");
        Group group2 = new Group("Group2");

        Student student1 = new Student("Student1");
        Student student2 = new Student("Student2");
        Student student3 = new Student("Student3");
        Student student4 = new Student("Student4");

        Teacher teacher1 = new Teacher("Teacher1");
        Teacher teacher2 = new Teacher("Teacher2");
        Teacher teacher3 = new Teacher("Teacher3");
        Teacher teacher4 = new Teacher("Teacher4");

        Lesson lesson1 = new Lesson("Lesson1", new Room("Room1"));
        Lesson lesson2 = new Lesson("Lesson2", new Room("Room2"));
        Lesson lesson3 = new Lesson("Lesson3", new Room("Room3"));
        Lesson lesson4 = new Lesson("Lesson4", new Room("Room4"));

        teacher1.AddLesson(lesson1);
        teacher2.AddLesson(lesson2);
        teacher3.AddLesson(lesson3);
        teacher4.AddLesson(lesson4);

        group1.AddLesson(lesson1);
        group1.AddLesson(lesson2);
        group2.AddLesson(lesson3);
        group2.AddLesson(lesson4);

        group1.AddStudent(student1);
        group1.AddStudent(student2);
        group2.AddStudent(student3);
        group2.AddStudent(student4);

        cathedra1.AddTeacher(teacher1);
        cathedra1.AddTeacher(teacher2);
        cathedra2.AddTeacher(teacher3);
        cathedra2.AddTeacher(teacher4);

        cathedra1.AddGroup(group1);
        cathedra2.AddGroup(group2);

        faculty1.AddCathedra(cathedra1);
        faculty2.AddCathedra(cathedra2);

        university.AddFaculty(faculty1);
        university.AddFaculty(faculty2);

        Console.WriteLine(university.ToString());
        foreach (var faculty in university.GetFaculties())
        {
            Console.WriteLine(faculty.ToString());
            foreach (var cathedra in faculty.GetCathedras())
            {
                Console.WriteLine(cathedra.ToString());
                foreach (var group in cathedra.GetGroups())
                {
                    Console.WriteLine(group.ToString());
                    foreach (var lesson in group.GetLessons())
                    {
                        Console.WriteLine(lesson.ToString() + " " + lesson.GetRoom());
                    }
                    foreach (var student in group.GetStudents())
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
                foreach (var teacher in cathedra.GetTeachers())
                {
                    Console.WriteLine(teacher.ToString());
                }
            }
        }
    }
}