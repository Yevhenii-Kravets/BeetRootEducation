using Newtonsoft.Json;

namespace Items
{
    [Serializable]
    public class User
    {
        [JsonProperty]
        private Guid ID { get; set; }
        [JsonProperty]
        private string Name { get; set; }

        public User(string Name)
        {
            this.ID = Guid.NewGuid();
            this.Name = Name;
        }
        
        public override string ToString() => Name;
    }
}
