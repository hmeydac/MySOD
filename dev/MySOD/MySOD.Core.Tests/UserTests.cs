namespace MySOD.Core.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserTests
    {
        private User user;

        private StartOfDay startOfDay;

        [TestInitialize]
        public void SetUp()
        {
            this.user = new User("Test Name");
            this.startOfDay = this.user.CreateStartOfDay(new DateTime(2013,10,28));
        }

        [TestMethod]
        public void UserMustHaveAName()
        {
            Assert.AreEqual("Test Name", this.user.Name);
        }

        [TestMethod]
        public void StartOfDayMustHaveADate()
        {
            
            Assert.AreEqual(new DateTime(2013, 10, 28), this.startOfDay.Date);
        }

        [TestMethod]
        public void StartOfDayCouldHaveCommitments()
        {
            Assert.AreEqual(0, this.startOfDay.Commitments.Count);
            this.startOfDay.AddCommitment("Test");
            Assert.AreEqual(1, this.startOfDay.Commitments.Count);
        }

        [TestMethod]
        public void RemoveCommitmentShouldRemoveItFromStartOfDay()
        {
            this.startOfDay.AddCommitment("Test");
            Assert.AreEqual(1, this.startOfDay.Commitments.Count);
            this.startOfDay.RemoveCommitment(0);
            Assert.AreEqual(0, this.startOfDay.Commitments.Count);
        }

        [TestMethod]
        public void CommitmentMustHaveText()
        {
            var commitment = this.startOfDay.AddCommitment("Test");
            Assert.AreEqual("Test", commitment.Text);
        }

        [TestMethod]
        public void CommitmentCouldHaveAssignedUser()
        {
            var commitment = this.startOfDay.AddCommitment("Test");
            commitment.AssignedUser = this.user;
            Assert.AreEqual(this.user, commitment.AssignedUser);
        }
    }
}
