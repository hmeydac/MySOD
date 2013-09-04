namespace MySOD.UI.Commands
{
    using System;

    public class CommandExecutionEventArgs : EventArgs
    {
        public CommandExecutionEventArgs(object result)
        {
            this.Result = result;
        }

        public object Result { get; set; }
    }
}
