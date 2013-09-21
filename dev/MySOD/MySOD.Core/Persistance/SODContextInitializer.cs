namespace MySOD.Core.Persistance
{
    using System.Data.Entity;

    public class SODContextInitializer<TContext>
        : MigrateDatabaseToLatestVersion<TContext, Migrations.Configuration<TContext>>
        where TContext : SODContext
    {
    }
}