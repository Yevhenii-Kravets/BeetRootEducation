using System.Text.RegularExpressions;

namespace OOP_Module
{
    public class University
    {
        private string Name { get; set; }
        private List<Faculty> Faculties { get; set; }

        // name
        public University(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("University:Name is Empty");

            Faculties = new List<Faculty>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("University:Name is Empty");
        }

        // faculty
        public bool AddFaculty(Faculty Faculty)
        {

            bool isHave = false;
            foreach(var faculty in Faculties)
            {
                if(faculty.ToString() == Faculty.ToString())
                    isHave = true;
            }

            if (!isHave)
            {
                Faculty.PushUniversity(this);
                Faculties.Add(Faculty);
                return true;
            }

            return false;
        }
        public bool RemoveFaculty(string nameFaculty)
        {
            foreach(var faculty in Faculties)
            {
                if (faculty.ToString() == nameFaculty)
                {
                    Faculties.Remove(faculty); 
                    return true;
                }
            }
            return false;
        }
        public List<Faculty> GetFaculties() => Faculties;

        // info
        public override string ToString() => Name;
    }
}
