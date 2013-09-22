namespace MySOD.Core.Tests
{
    using System.Linq;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core.Persistance;

    [TestClass]
    public class PersistanceAgentTests : TransactionalUnitTest
    {
        [TestMethod]
        public void OnStartOfDayInsertDetectedSaveInDatabase()
        {
            var user = new User("Test Name");
            var agent = new PersistanceAgent<StartOfDay>(user);
            user.CreateStartOfDay(new System.DateTime(2013, 10, 28));
            Assert.AreEqual(1, agent.Get().Count());
        }

        [TestMethod]
        public void OnCommitmentInsertDetectedSaveInDatabase()
        {
            var startOfDay = new StartOfDay();
            var agent = new PersistanceAgent<Commitment>(startOfDay);
            startOfDay.AddCommitment("Do tests");
            Assert.AreEqual(1, agent.Get().Count());
        }

        [TestMethod]
        public void OnCommitmentRemoveDetectedDeleteFromDatabase()
        {
            var startOfDay = new StartOfDay();
            var agent = new PersistanceAgent<Commitment>(startOfDay);
            startOfDay.AddCommitment("Do tests");
            Assert.AreEqual(1, agent.Get().Count());
            startOfDay.RemoveCommitment(0);
            Assert.AreEqual(0, agent.Get().Count());
        }

        public override void SetUp()
        {
        }
    }
}
