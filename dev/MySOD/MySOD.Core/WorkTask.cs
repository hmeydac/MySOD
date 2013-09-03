namespace MySOD.Core
{
    public class WorkTask
    {
        public string Title { get; set; }

        public bool IsCompleted { get; private set; }

        public void Complete()
        {
            this.IsCompleted = true;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
