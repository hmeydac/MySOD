namespace MySOD.Core
{
    using System;

    public class PersistanceEventArgs : EventArgs
    {
        public PersistanceEventArgs(object data)
        {
            this.Entity = data;
        }

        public object Entity { get; set; }
    }
}
