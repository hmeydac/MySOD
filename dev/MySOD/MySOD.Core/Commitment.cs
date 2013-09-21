namespace MySOD.Core
{
    public class Commitment
    {
        internal Commitment(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }

        public User AssignedUser { get; set; }
    }
}