namespace MySOD.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : PersistanceEntity
    {
        public User(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public StartOfDay CreateStartOfDay(DateTime date)
        {
            var startOfDay = new StartOfDay(date);
            this.RaiseInsertEvent(startOfDay);
            return startOfDay;
        }
    }
}
