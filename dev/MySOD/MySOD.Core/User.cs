namespace MySOD.Core
{
    using System;

    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public StartOfDay CreateStartOfDay(DateTime date)
        {
            return new StartOfDay(date);
        }
    }
}
