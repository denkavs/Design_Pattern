using System;

namespace Patterns_Design.Behavioral.Command
{
    internal class TemplatedCommand<T> : ICommand<T>
    {
        private Action<T> execute;

        public TemplatedCommand(Action<T> action)
        {
            execute = action;
        }

        public void Execute(T param)
        {
            if (this.execute != null)
            {
                this.execute(param);
            }
        }
    }
}