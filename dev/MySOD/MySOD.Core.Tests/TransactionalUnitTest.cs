namespace MySOD.Core.Tests
{
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class TransactionalUnitTest
    {
        private TransactionScope transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            this.transactionScope = new TransactionScope();
            this.SetUp();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.transactionScope.Dispose();
        }

        public abstract void SetUp();
    }
}
