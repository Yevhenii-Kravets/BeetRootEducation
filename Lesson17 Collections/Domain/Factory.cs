using Items;
using System.Text.Json;

namespace Domain
{
    public static class Factory
    {
        public static IRepository GetRepository()
        {
            return new Repository();
        }

        public static void SaveRepository(Channel Channel)
        {
            new Repository().SaveChannel(Channel);
        }
    }
}
