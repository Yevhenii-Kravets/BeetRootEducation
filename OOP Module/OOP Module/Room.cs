namespace OOP_Module
{
    public class Room
    {
        private string Name { get; set; }
        public Room(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                this.Name = Name;
            else
                throw new ArgumentException("Room:Name is Empty");
        }

        public override string ToString() => Name;
    }
}
