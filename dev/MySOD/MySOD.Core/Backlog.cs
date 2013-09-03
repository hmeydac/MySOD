namespace MySOD.Core
{
    using System.Collections.Generic;

    public class Backlog
    {
        private readonly List<WorkTask> tasks = new List<WorkTask>(); 

        public void Add(WorkTask task)
        {
            this.tasks.Add(task);
        }

        public int TaskCount()
        {
            return this.tasks.Count;
        }

        public WorkTask GetTask(int index)
        {
            return this.tasks[index];
        }

        public void Remove(int index)
        {
            this.tasks.RemoveAt(index);
        }
    }
}
