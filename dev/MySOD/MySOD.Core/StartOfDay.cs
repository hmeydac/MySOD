namespace MySOD.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StartOfDay : PersistanceEntity
    {
        public StartOfDay()
        {
            
        }

        internal StartOfDay(DateTime date)
        {
            this.Id = Guid.NewGuid();
            this.Date = date;
            this.Commitments = new List<Commitment>();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public List<Commitment> Commitments { get; set; }

        public Commitment AddCommitment(string text)
        {
            var commitment = new Commitment(text);
            this.Commitments.Add(commitment);
            this.RaiseInsertEvent(commitment);
            return commitment;
        }

        public void RemoveCommitment(int index)
        {
            this.Commitments.RemoveAt(index);
        }
    }
}
