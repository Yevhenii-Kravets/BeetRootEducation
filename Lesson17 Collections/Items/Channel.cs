using Newtonsoft.Json;

namespace Items
{
    [Serializable]
    public class Channel
    {
        [JsonProperty]
        private string Name { get; set; }
        [JsonProperty]
        private Queue<User> Users { get; set; }
        [JsonProperty]
        private HashSet<Voting> Votings { get; set; }

        public void AddUserToChannel(User User)
        {
            Users.Enqueue(User);
        }
        public User GetUserFromChannel()
        {
            return Users.Dequeue();
        }

        public void AddVotingToChannel(Voting Voting)
        {
            Votings.Add(Voting);
        }
        public List<Voting> GetVotingsFromChannel()
        {
            if (Votings.Count > 0)
                return Votings.ToList();
            else
                return new List<Voting>();
        }

        public void SerializeChannel(string path)
        {
            if (!File.Exists(path))
                using (File.Create(path)) { }

            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }
        public void DeserializeChannel(string path)
        {
            if (!File.Exists(path))
                using (File.Create(path)) { }

            string json = File.ReadAllText(path);
            if (!string.IsNullOrWhiteSpace(json))
            {
                Channel state = JsonConvert.DeserializeObject<Channel>(json);

                Name = state.Name;
                Users = state.Users;
                Votings = state.Votings;

                if (Users == null)
                    Users = new Queue<User>();
                if (Votings == null)
                    Votings = new HashSet<Voting>();
            }
        }

        public void SetName(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                this.Name = Name;
            }
        }
        public override string ToString() => Name;
    }
}
