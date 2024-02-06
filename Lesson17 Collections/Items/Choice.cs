using Newtonsoft.Json;

namespace Items
{
    [Serializable]
    public class Choice
    {
        [JsonProperty]
        private string Title { get; set; }
        [JsonProperty]
        private HashSet<User> Users { get; set; }

        public Choice(string Title)
        {
            this.Title = Title;
            Users = new HashSet<User>();
        }

        public int GetCountVotes() => Users.Count;
        public void SetVote(User user)
        {
            Users.Add(user);
        }

        public override string ToString() => Title;
    }
}
