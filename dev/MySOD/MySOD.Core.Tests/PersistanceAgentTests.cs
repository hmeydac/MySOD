namespace MySOD.Core.Tests
{
    using System.Linq;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core.Persistance;

    [TestClass]
    public class PersistanceAgentTests
    {
        private TransactionScope transactionScope;

        [TestInitialize]
        public void SetUp()
        {
            this.transactionScope = new TransactionScope();
        }

        [TestMethod]
        public void OnStartOfDayInsertDetectedSaveInDatabase()
        {
            var user = new User("Test Name");
            var agent = new PersistanceAgent<StartOfDay>(user);
            user.CreateStartOfDay(new System.DateTime(2013, 10, 28));
            Assert.AreEqual(1, agent.Get().Count());
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.transactionScope.Dispose();
        }
    }
}
