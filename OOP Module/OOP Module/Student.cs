namespace OOP_Module
{
    public class Student
    {
        private string Name { get; set; }
        private Group? Group { get; set; }

        // name
        public Student(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Student:Name is Empty");
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Student:Name is Empty");
        }

        // Group
        public void PushGroup(Group Group)
        {
            if (Group == null)
                this.Group = Group;
            else
            {
                Group.RemoveStudent(this.Name);
                this.Group = Group;
            }
        }

        // info
        public override string ToString() => Name;
    }
}
