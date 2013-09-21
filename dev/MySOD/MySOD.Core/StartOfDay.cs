namespace MySOD.Core
{
    using System;
    using System.Collections.Generic;

    public class StartOfDay
    {
        internal StartOfDay(DateTime date)
        {
            this.Date = date;
            this.Commitments = new List<Commitment>();
        }

        public DateTime Date { get; set; }

        public List<Commitment> Commitments { get; set; }

        public Commitment AddCommitment(string text)
        {
            var commitment = new Commitment(text);
            this.Commitments.Add(commitment);
            return commitment;
        }

        public void RemoveCommitment(int index)
        {
            this.Commitments.RemoveAt(index);
        }
    }
}
