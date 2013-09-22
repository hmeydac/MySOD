namespace MySOD.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Commitment
    {
        public Commitment()
            : this(string.Empty)
        {
            
        }

        public Commitment(string text)
        {
            this.Id = Guid.NewGuid();
            this.Text = text;
        }

        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public User AssignedUser { get; set; }
    }
}