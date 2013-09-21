namespace MySOD.Core
{
    using System;

    public abstract class PersistanceEntity
    {
        internal event EventHandler<PersistanceEventArgs> EntityInserted;

        internal event EventHandler<PersistanceEventArgs> EntityRemoved;

        internal event EventHandler<PersistanceEventArgs> EntityUpdated;

        protected void RaiseInsertEvent(object data)
        {
            this.RaiseEvent(this.EntityInserted, data);
        }

        protected void RaiseRemovedEvent(object data)
        {
            this.RaiseEvent(this.EntityRemoved, data);
        }

        protected void RaiseUpdatedEvent(object data)
        {
            this.RaiseEvent(this.EntityUpdated, data);
        }

        private void RaiseEvent(EventHandler<PersistanceEventArgs> eventToRaise, object data)
        {
            if (eventToRaise != null)
            {
                eventToRaise(this, new PersistanceEventArgs(data));
            }
        }
    }
}
