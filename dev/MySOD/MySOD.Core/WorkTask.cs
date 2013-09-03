namespace MySOD.Core
{
    public class WorkTask
    {
        private bool isCompleted;

        public string Title { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public bool ForToday { get; set; }

        public bool IsCompleted()
        {
            return this.isCompleted;
        }

        public void Complete()
        {
            this.isCompleted = true;
        }
    }
}
