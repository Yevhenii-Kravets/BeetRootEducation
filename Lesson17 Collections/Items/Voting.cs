using Newtonsoft.Json;

namespace Items
{
    [Serializable]
    public class Voting
    {
        [JsonProperty]
        private Guid ID { get; set; }
        [JsonProperty]
        private string Title { get; set; }
        [JsonProperty]
        private List<Choice> Choices { get; set; }

        public Voting(string Title)
        {
            ID = Guid.NewGuid();
            this.Title = Title;
            this.Choices = new List<Choice>();
        }

        public void AddChoice(string Title)
        {
            Choices.Add(new Choice(Title));
        }

        public string GetID() => ID.ToString();
        public bool Vote(int index, User user)
        {
            if (Choices.ElementAt(index - 1) == null)
                return false;
            else
                Choices[index - 1].SetVote(user);

            return true;
        }
        public List<Choice> GetChoices() => Choices;
        public override string ToString() => Title;
    }
}
