using System.Data.Entity.Migrations;

namespace BREntityFramework.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<BREntityFramework.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BREntityFramework.ShopDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
