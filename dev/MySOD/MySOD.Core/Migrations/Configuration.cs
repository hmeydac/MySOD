namespace MySOD.Core.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    using MySOD.Core.Persistance;

    [ExcludeFromCodeCoverage]
    public class Configuration<TContext> : DbMigrationsConfiguration<TContext>
        where TContext : SODContext
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TContext context)
        {
        }
    }
}
