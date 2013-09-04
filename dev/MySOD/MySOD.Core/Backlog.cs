namespace MySOD.Core
{
    using System.Collections;
    using System.Collections.Generic;

    public class Backlog
    {
        private readonly List<WorkTask> tasks = new List<WorkTask>(); 

        public void Add(WorkTask task)
        {
            this.tasks.Add(task);
        }

        public int TaskCount
        {
            get { return this.tasks.Count; }
        }

        public WorkTask GetTask(int index)
        {
            return this.tasks[index];
        }

        public void Remove(int index)
        {
            this.tasks.RemoveAt(index);
        }

        public void Remove(WorkTask task)
        {
            this.tasks.Remove(task);
        }

        public List<WorkTask> GetList()
        {
            return this.tasks;
        }

        public void Replace(WorkTask toUpdateTask, int index)
        {            
            this.tasks[index] = toUpdateTask;
        }

        public bool Contains(WorkTask task)
        {
            return this.tasks.Contains(task);
        }
    }
}
