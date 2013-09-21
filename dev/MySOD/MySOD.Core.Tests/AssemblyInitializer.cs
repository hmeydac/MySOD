namespace MySOD.Core.Tests
{
    using System.Data.Entity;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core.Persistance;

    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            // Ensure database is created before any test is run
            Database.SetInitializer<SODContext>(new SODContextInitializer<SODContext>());
            var context = new SODContext();
            context.Database.Initialize(force: false);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            // Remove database after all tests ran
            var context = new SODContext();
            context.Database.Delete();
        }
    }
}
