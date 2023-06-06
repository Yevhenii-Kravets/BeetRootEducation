namespace OOP_Module
{
    public class Faculty
    {
        private string Name { get; set; }
        private University? University { get; set; }
        private List<Cathedra> Cathedras { get; set; }

        // name
        public Faculty(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Faculty:Name is Empty");

            Cathedras = new List<Cathedra>();
        }
        public void Rename(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Faculty:Name is Empty");
        }

        // university
        public void PushUniversity(University University)
        {
            if (University == null)
                this.University = University;
            else
            {
                University.RemoveFaculty(this.Name);
                this.University = University;
            }
        }

        // cathedras
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
                Cathedra.PushFaculty(this);
                Cathedras.Add(Cathedra);
                return true;
            }

            return false;
        }
        public bool RemoveCathedra(string nameCathedra)
        {
            foreach (var cathedra in Cathedras)
            {
                if (cathedra.ToString() == nameCathedra)
                {
                    Cathedras.Remove(cathedra);
                    return true;
                }
            }
            return false;
        }
        public List<Cathedra> GetCathedras() => Cathedras;

        // info
        public override string ToString() => Name;
    }
}
