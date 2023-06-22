using Items;


namespace Domain
{
    internal class Repository : IRepository
    {
        private const string FileName = "ChannelDB.json";

        public Channel GetChannel()
        {
            var channel = new Channel();
            channel.DeserializeChannel(FileName);
            return channel;
        }

        public void SaveChannel(Channel Channel)
        {
            Channel.SerializeChannel(FileName);
        }
    }
}